﻿// 
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
// $Id: Map.cs 152 2009-08-24 14:19:58Z latifer@gmail.com $
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Radegast;
using OpenMetaverse;

namespace Radegast.Plugin.Demo
{
    public class DemoPlugin : IRadegastPlugin
    {
        private RadegastInstance Instance;
        private GridClient Client { get { return Instance.Client; } }

        private string version = "1.0";

        public void StartPlugin(RadegastInstance inst)
        {
            Instance = inst;
            Instance.MainForm.TabConsole.DisplayNotificationInChat("Demo Plugin version 1.0 loaded");

            // We want to process incoming chat in this plugin
            Client.Self.OnChat += new AgentManager.ChatCallback(Self_OnChat);

            // Ok, we want to answer to IMs as well
            Client.Self.OnInstantMessage += new AgentManager.InstantMessageCallback(Self_OnInstantMessage);

            // Automatically handle notifications (blue dialogs)
            Notification.OnNotificationDisplayed += new Notification.NotificationCallback(Notification_OnNotificationDisplayed);
        }

        public void StopPlugin(RadegastInstance instance)
        {
            // Unregister events
            Client.Self.OnChat -= new AgentManager.ChatCallback(Self_OnChat);
            Client.Self.OnInstantMessage -= new AgentManager.InstantMessageCallback(Self_OnInstantMessage);
            Notification.OnNotificationDisplayed -= new Notification.NotificationCallback(Notification_OnNotificationDisplayed);
        }

        void Notification_OnNotificationDisplayed(object sender, NotificationEventArgs e)
        {
            // Example: auto accept friendship offers after 2 seconds of "thinking" ;)
            if (e.Type == NotificationType.FriendshipOffer)
            {
                Thread.Sleep(2000);
                // Execute on GUI thread
                Instance.MainForm.BeginInvoke(new MethodInvoker(() =>
                    {
                        e.Buttons[0].PerformClick();
                    }
                    ));
            }
        }

        void Self_OnChat(string message, ChatAudibleLevel audible, ChatType type, ChatSourceType sourceType, string fromName, UUID id, UUID ownerid, Vector3 position)
        {
            // We ignore everything except normal chat from other avatars

            if (type != ChatType.Normal || sourceType != ChatSourceType.Agent)
            {
                return;
            }

            // See if somone said the magic words
            if (message.ToLower() == "demo plugin version")
            {
                // Turn towards the person who spoke
                Client.Self.Movement.TurnToward(position);

                // Play typing animation for 1 second
                Instance.State.SetTyping(true);
                Thread.Sleep(1000);
                Instance.State.SetTyping(false);

                // Finally send the answer back
                Client.Self.Chat("Hello " + fromName + ", glad you asked. My version is " + version + ".", 0, ChatType.Normal);
            }
        }

        void Self_OnInstantMessage(InstantMessage im, Simulator simulator)
        {
            // Every event coming from a different thread (almost all of them, most certanly those
            // from libomv) needs to be executed on the GUI thread. This code can be basically
            // copy-pasted on the begining of each libomv event handler that results in update 
            // of any GUI element
            //
            // In this case the IM we sent back as a reply is also displayed in the corresponding IM tab
            if (Instance.MainForm.InvokeRequired)
            {
                Instance.MainForm.BeginInvoke(
                    new MethodInvoker(
                        delegate()
                        {
                            Self_OnInstantMessage(im, simulator);
                        }
                        ));
                return;
            }

            // We need to filter out all sorts of things that come in as a instante message
            if (im.Dialog == InstantMessageDialog.MessageFromAgent // Message is not notice, inv. offer, etc etc
                && !Instance.Groups.ContainsKey(im.IMSessionID)  // Message is not group IM (sessionID == groupID)
                && im.BinaryBucket.Length < 2                    // Session is not ad-hoc friends conference
                && im.FromAgentName != "Second Life"             // Not a system message
                )
            {
                if (im.Message == "demo plugin version")
                {
                    Instance.Netcom.SendInstantMessage(
                        string.Format("Hello {0}, my version is {1}", im.FromAgentName, version),
                        im.FromAgentID,
                        im.IMSessionID);
                }
            }
        }
    }
}
