// 
// Radegast Metaverse Client
// Copyright (c) 2009, Radegast Development Team
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the application "Radegast", nor the names of its
//       contributors may be used to endorse or promote products derived from
//       this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// $Id$
//
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Radegast.Netcom;
using OpenMetaverse;

namespace Radegast
{
    public partial class GroupIMTabWindow : UserControl
    {
        private RadegastInstance instance;
        private GridClient client { get { return instance.Client; } }
        private RadegastNetcom netcom { get { return instance.Netcom; } }
        private UUID session;
        private IMTextManager textManager;

        ManualResetEvent WaitForSessionStart = new ManualResetEvent(false);

        public GroupIMTabWindow(RadegastInstance instance, UUID session, string sessionName)
        {
            InitializeComponent();
            Disposed += new EventHandler(IMTabWindow_Disposed);

            this.instance = instance;
            this.session = session;

            textManager = new IMTextManager(this.instance, new RichTextBoxPrinter(rtbIMText), this.session, sessionName);

            btnShow.Text = "Show";
            chatSplit.Panel2Collapsed = true;

            // Callbacks
            client.Self.OnGroupChatJoin += new AgentManager.GroupChatJoinedCallback(Self_OnGroupChatJoin);
            client.Self.OnChatSessionMemberAdded += new AgentManager.ChatSessionMemberAddedCallback(Self_OnChatSessionMemberAdded);
            client.Self.OnChatSessionMemberLeft += new AgentManager.ChatSessionMemberLeftCallback(Self_OnChatSessionMemberLeft);
            client.Avatars.OnAvatarNames += new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
            client.Self.RequestJoinGroupChat(session);
        }

        private void IMTabWindow_Disposed(object sender, EventArgs e)
        {
            client.Self.RequestLeaveGroupChat(session);
            client.Self.OnGroupChatJoin -= new AgentManager.GroupChatJoinedCallback(Self_OnGroupChatJoin);
            client.Self.OnChatSessionMemberAdded -= new AgentManager.ChatSessionMemberAddedCallback(Self_OnChatSessionMemberAdded);
            client.Self.OnChatSessionMemberLeft -= new AgentManager.ChatSessionMemberLeftCallback(Self_OnChatSessionMemberLeft);
            client.Avatars.OnAvatarNames -= new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
            CleanUp();
        }

        void Avatars_OnAvatarNames(Dictionary<UUID, string> names)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => Avatars_OnAvatarNames(names)));
                return;
            }

            Participants.BeginUpdate();

            foreach (KeyValuePair<UUID, string> kvp in names)
            {
                if (Participants.Items.ContainsKey(kvp.Key.ToString()))
                    Participants.Items[kvp.Key.ToString()].Text = kvp.Value;
            }

            Participants.Sort();
            Participants.EndUpdate();
        }

        void Self_OnChatSessionMemberLeft(UUID sessionID, UUID agent_key)
        {
            if (sessionID == session)
                UpdateParticipantList();
        }

        void Self_OnChatSessionMemberAdded(UUID sessionID, UUID agent_key)
        {
            if (sessionID == session)
                UpdateParticipantList();
        }

        void UpdateParticipantList()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(UpdateParticipantList));
                return;
            }

            Participants.BeginUpdate();
            Participants.Items.Clear();

            List<ChatSessionMember> participants;
            List<UUID> nameLookup = new List<UUID>();

            if (client.Self.GroupChatSessions.TryGetValue(session, out participants))
            {
                ChatSessionMember[] members = participants.ToArray();
                for (int i = 0; i < members.Length; i++)
                {
                    ChatSessionMember participant = members[i];
                    ListViewItem item = new ListViewItem();
                    item.Name = participant.AvatarKey.ToString();
                    if (instance.nameCache.ContainsKey(participant.AvatarKey))
                    {
                        item.Text = instance.nameCache[participant.AvatarKey];
                    }
                    else
                    {
                        item.Text = RadegastInstance.INCOMPLETE_NAME;
                        nameLookup.Add(participant.AvatarKey);
                    }
                    if (participant.IsModerator)
                        item.Font = new Font(item.Font, FontStyle.Bold);
                    Participants.Items.Add(item);
                }

                if (nameLookup.Count > 0)
                    client.Avatars.RequestAvatarNames(nameLookup);
            }

            Participants.Sort();
            Participants.EndUpdate();
        }

        void Self_OnGroupChatJoin(UUID groupChatSessionID, string sessionName, UUID tmpSessionID, bool success)
        {
            if (groupChatSessionID != session && tmpSessionID != session)
            {
                return;
            }

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(
                    delegate()
                    {
                        Self_OnGroupChatJoin(groupChatSessionID, sessionName, tmpSessionID, success);
                    }
                    )
                );
                return;
            }
            if (success)
            {
                textManager.TextPrinter.PrintTextLine("Join Group Chat Success!", Color.Green);
                WaitForSessionStart.Set();
            }
            else
            {
                textManager.TextPrinter.PrintTextLine("Join Group Chat failed.", Color.Red);
            }
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoginStatus += new EventHandler<ClientLoginEventArgs>(netcom_ClientLoginStatus);
            netcom.ClientDisconnected += new EventHandler<ClientDisconnectEventArgs>(netcom_ClientDisconnected);
        }

        private void netcom_ClientLoginStatus(object sender, ClientLoginEventArgs e)
        {
            if (e.Status != LoginStatus.Success) return;

            RefreshControls();
        }

        private void netcom_ClientDisconnected(object sender, ClientDisconnectEventArgs e)
        {
            RefreshControls();
        }

        public void CleanUp()
        {
            textManager.CleanUp();
            textManager = null;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMsg();
            this.ClearIMInput();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (chatSplit.Panel2Collapsed)
            {
                chatSplit.Panel2Collapsed = false;
                btnShow.Text = "Hide";
            }
            else
            {
                chatSplit.Panel2Collapsed = true;
                btnShow.Text = "Show";
            }
        }

        private void cbxInput_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void RefreshControls()
        {
            if (!netcom.IsLoggedIn)
            {
                cbxInput.Enabled = false;
                btnSend.Enabled = false;
                btnShow.Enabled = false;
                btnShow.Text = "Show";
                chatSplit.Panel2Collapsed = true;
                return;
            }

            btnShow.Enabled = true;

            if (cbxInput.Text.Length > 0)
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
            }
        }

        private void cbxInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;

            SendMsg();
        }

        private void SendMsg()
        {
            if (cbxInput.Text.Length == 0) return;

            string message = cbxInput.Text;
            if (message.Length > 1023) message = message.Remove(1023);

            if (!client.Self.GroupChatSessions.ContainsKey(session))
            {
                WaitForSessionStart.Reset();
                client.Self.RequestJoinGroupChat(session);
            }
            else
            {
                WaitForSessionStart.Set();
            }

            if (WaitForSessionStart.WaitOne(10000, false))
            {
                client.Self.InstantMessageGroup(session, message);
            }
            else
            {
                textManager.TextPrinter.PrintTextLine("Cannot send group IM.", Color.Red);
            }
            this.ClearIMInput();
        }

        private void ClearIMInput()
        {
            cbxInput.Items.Add(cbxInput.Text);
            cbxInput.Text = string.Empty;
        }

        public void SelectIMInput()
        {
            cbxInput.Select();
        }

        private void rtbIMText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            instance.MainForm.ProcessLink(e.LinkText);
        }

        private void cbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        public UUID SessionId
        {
            get { return session; }
            set { session = value; }
        }

        public IMTextManager TextManager
        {
            get { return textManager; }
            set { textManager = value; }
        }

        private void Participants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = Participants.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                try
                {
                    instance.MainForm.ShowAgentProfile(item.Text, new UUID(item.Name));
                }
                catch (Exception) { }
            }
        }

    }
}
