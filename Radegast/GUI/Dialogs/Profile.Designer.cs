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
namespace Radegast
{
    partial class frmProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            this.tabProfile = new System.Windows.Forms.TabControl();
            this.tpgProfile = new System.Windows.Forms.TabPage();
            this.btnIM = new System.Windows.Forms.Button();
            this.btnFriend = new System.Windows.Forms.Button();
            this.slPicPanel = new System.Windows.Forms.Panel();
            this.btnOfferTeleport = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.rtbAccountInfo = new System.Windows.Forms.RichTextBox();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPartner = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBornOn = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpgWeb = new System.Windows.Forms.TabPage();
            this.pnlWeb = new System.Windows.Forms.Panel();
            this.btnWebOpen = new System.Windows.Forms.Button();
            this.btnWebView = new System.Windows.Forms.Button();
            this.txtWebURL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbpPicks = new System.Windows.Forms.TabPage();
            this.pickDetailPanel = new System.Windows.Forms.Panel();
            this.pickDetail = new System.Windows.Forms.TextBox();
            this.pickLocation = new System.Windows.Forms.TextBox();
            this.picksLowerPanel = new System.Windows.Forms.Panel();
            this.btnShowOnMap = new System.Windows.Forms.Button();
            this.btnTeleport = new System.Windows.Forms.Button();
            this.pickTitle = new System.Windows.Forms.TextBox();
            this.pickPicturePanel = new System.Windows.Forms.Panel();
            this.pickListPanel = new System.Windows.Forms.Panel();
            this.tpgFirstLife = new System.Windows.Forms.TabPage();
            this.rlPicPanel = new System.Windows.Forms.Panel();
            this.rtbAboutFL = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabProfile.SuspendLayout();
            this.tpgProfile.SuspendLayout();
            this.tpgWeb.SuspendLayout();
            this.tbpPicks.SuspendLayout();
            this.pickDetailPanel.SuspendLayout();
            this.picksLowerPanel.SuspendLayout();
            this.tpgFirstLife.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabProfile
            // 
            this.tabProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProfile.Controls.Add(this.tpgProfile);
            this.tabProfile.Controls.Add(this.tpgWeb);
            this.tabProfile.Controls.Add(this.tbpPicks);
            this.tabProfile.Controls.Add(this.tpgFirstLife);
            this.tabProfile.Location = new System.Drawing.Point(12, 12);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.SelectedIndex = 0;
            this.tabProfile.Size = new System.Drawing.Size(468, 483);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.SelectedIndexChanged += new System.EventHandler(this.tabProfile_SelectedIndexChanged);
            // 
            // tpgProfile
            // 
            this.tpgProfile.Controls.Add(this.btnIM);
            this.tpgProfile.Controls.Add(this.btnFriend);
            this.tpgProfile.Controls.Add(this.slPicPanel);
            this.tpgProfile.Controls.Add(this.btnOfferTeleport);
            this.tpgProfile.Controls.Add(this.btnPay);
            this.tpgProfile.Controls.Add(this.rtbAccountInfo);
            this.tpgProfile.Controls.Add(this.rtbAbout);
            this.tpgProfile.Controls.Add(this.txtUUID);
            this.tpgProfile.Controls.Add(this.label9);
            this.tpgProfile.Controls.Add(this.txtPartner);
            this.tpgProfile.Controls.Add(this.label5);
            this.tpgProfile.Controls.Add(this.label4);
            this.tpgProfile.Controls.Add(this.label3);
            this.tpgProfile.Controls.Add(this.txtBornOn);
            this.tpgProfile.Controls.Add(this.txtFullName);
            this.tpgProfile.Controls.Add(this.label2);
            this.tpgProfile.Controls.Add(this.label1);
            this.tpgProfile.Location = new System.Drawing.Point(4, 22);
            this.tpgProfile.Name = "tpgProfile";
            this.tpgProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tpgProfile.Size = new System.Drawing.Size(460, 457);
            this.tpgProfile.TabIndex = 0;
            this.tpgProfile.Text = "Profile";
            this.tpgProfile.UseVisualStyleBackColor = true;
            // 
            // btnIM
            // 
            this.btnIM.Location = new System.Drawing.Point(312, 368);
            this.btnIM.Name = "btnIM";
            this.btnIM.Size = new System.Drawing.Size(96, 23);
            this.btnIM.TabIndex = 19;
            this.btnIM.Text = "Start IM";
            this.btnIM.UseVisualStyleBackColor = true;
            this.btnIM.Click += new System.EventHandler(this.btnIM_Click);
            // 
            // btnFriend
            // 
            this.btnFriend.Location = new System.Drawing.Point(210, 368);
            this.btnFriend.Name = "btnFriend";
            this.btnFriend.Size = new System.Drawing.Size(96, 23);
            this.btnFriend.TabIndex = 18;
            this.btnFriend.Text = "Add Friend";
            this.btnFriend.UseVisualStyleBackColor = true;
            this.btnFriend.Click += new System.EventHandler(this.btnFriend_Click);
            // 
            // slPicPanel
            // 
            this.slPicPanel.Location = new System.Drawing.Point(9, 33);
            this.slPicPanel.Name = "slPicPanel";
            this.slPicPanel.Size = new System.Drawing.Size(237, 178);
            this.slPicPanel.TabIndex = 17;
            // 
            // btnOfferTeleport
            // 
            this.btnOfferTeleport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOfferTeleport.Location = new System.Drawing.Point(6, 368);
            this.btnOfferTeleport.Name = "btnOfferTeleport";
            this.btnOfferTeleport.Size = new System.Drawing.Size(96, 23);
            this.btnOfferTeleport.TabIndex = 16;
            this.btnOfferTeleport.Text = "Offer Teleport";
            this.btnOfferTeleport.UseVisualStyleBackColor = true;
            this.btnOfferTeleport.Click += new System.EventHandler(this.btnOfferTeleport_Click);
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPay.Location = new System.Drawing.Point(108, 368);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(96, 23);
            this.btnPay.TabIndex = 15;
            this.btnPay.Text = "Pay...";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // rtbAccountInfo
            // 
            this.rtbAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAccountInfo.Location = new System.Drawing.Point(306, 60);
            this.rtbAccountInfo.Name = "rtbAccountInfo";
            this.rtbAccountInfo.ReadOnly = true;
            this.rtbAccountInfo.Size = new System.Drawing.Size(148, 133);
            this.rtbAccountInfo.TabIndex = 14;
            this.rtbAccountInfo.Text = "";
            // 
            // rtbAbout
            // 
            this.rtbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAbout.Location = new System.Drawing.Point(6, 231);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.Size = new System.Drawing.Size(448, 131);
            this.rtbAbout.TabIndex = 13;
            this.rtbAbout.Text = "";
            this.rtbAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbAbout_LinkClicked);
            // 
            // txtUUID
            // 
            this.txtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUUID.Location = new System.Drawing.Point(41, 430);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(259, 21);
            this.txtUUID.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 433);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Key:";
            // 
            // txtPartner
            // 
            this.txtPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartner.Location = new System.Drawing.Point(306, 33);
            this.txtPartner.Name = "txtPartner";
            this.txtPartner.ReadOnly = true;
            this.txtPartner.Size = new System.Drawing.Size(148, 21);
            this.txtPartner.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Partner:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "About:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Info:";
            // 
            // txtBornOn
            // 
            this.txtBornOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBornOn.Location = new System.Drawing.Point(306, 6);
            this.txtBornOn.Name = "txtBornOn";
            this.txtBornOn.ReadOnly = true;
            this.txtBornOn.Size = new System.Drawing.Size(148, 21);
            this.txtBornOn.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(50, 6);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(196, 21);
            this.txtFullName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Born on:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // tpgWeb
            // 
            this.tpgWeb.Controls.Add(this.pnlWeb);
            this.tpgWeb.Controls.Add(this.btnWebOpen);
            this.tpgWeb.Controls.Add(this.btnWebView);
            this.tpgWeb.Controls.Add(this.txtWebURL);
            this.tpgWeb.Controls.Add(this.label6);
            this.tpgWeb.Location = new System.Drawing.Point(4, 22);
            this.tpgWeb.Name = "tpgWeb";
            this.tpgWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tpgWeb.Size = new System.Drawing.Size(460, 457);
            this.tpgWeb.TabIndex = 1;
            this.tpgWeb.Text = "Web";
            this.tpgWeb.UseVisualStyleBackColor = true;
            // 
            // pnlWeb
            // 
            this.pnlWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeb.Location = new System.Drawing.Point(6, 33);
            this.pnlWeb.Name = "pnlWeb";
            this.pnlWeb.Size = new System.Drawing.Size(448, 418);
            this.pnlWeb.TabIndex = 4;
            // 
            // btnWebOpen
            // 
            this.btnWebOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebOpen.Enabled = false;
            this.btnWebOpen.Location = new System.Drawing.Point(379, 4);
            this.btnWebOpen.Name = "btnWebOpen";
            this.btnWebOpen.Size = new System.Drawing.Size(75, 23);
            this.btnWebOpen.TabIndex = 3;
            this.btnWebOpen.Text = "Open";
            this.btnWebOpen.UseVisualStyleBackColor = true;
            this.btnWebOpen.Click += new System.EventHandler(this.btnWebOpen_Click);
            // 
            // btnWebView
            // 
            this.btnWebView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebView.Enabled = false;
            this.btnWebView.Location = new System.Drawing.Point(298, 4);
            this.btnWebView.Name = "btnWebView";
            this.btnWebView.Size = new System.Drawing.Size(75, 23);
            this.btnWebView.TabIndex = 2;
            this.btnWebView.Text = "View";
            this.btnWebView.UseVisualStyleBackColor = true;
            this.btnWebView.Click += new System.EventHandler(this.btnWebView_Click);
            // 
            // txtWebURL
            // 
            this.txtWebURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebURL.Location = new System.Drawing.Point(42, 6);
            this.txtWebURL.Name = "txtWebURL";
            this.txtWebURL.ReadOnly = true;
            this.txtWebURL.Size = new System.Drawing.Size(250, 21);
            this.txtWebURL.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "URL:";
            // 
            // tbpPicks
            // 
            this.tbpPicks.Controls.Add(this.pickDetailPanel);
            this.tbpPicks.Controls.Add(this.pickListPanel);
            this.tbpPicks.Location = new System.Drawing.Point(4, 22);
            this.tbpPicks.Name = "tbpPicks";
            this.tbpPicks.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPicks.Size = new System.Drawing.Size(460, 457);
            this.tbpPicks.TabIndex = 3;
            this.tbpPicks.Text = "Picks";
            this.tbpPicks.UseVisualStyleBackColor = true;
            // 
            // pickDetailPanel
            // 
            this.pickDetailPanel.Controls.Add(this.pickDetail);
            this.pickDetailPanel.Controls.Add(this.pickLocation);
            this.pickDetailPanel.Controls.Add(this.picksLowerPanel);
            this.pickDetailPanel.Controls.Add(this.pickTitle);
            this.pickDetailPanel.Controls.Add(this.pickPicturePanel);
            this.pickDetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickDetailPanel.Location = new System.Drawing.Point(142, 3);
            this.pickDetailPanel.Name = "pickDetailPanel";
            this.pickDetailPanel.Size = new System.Drawing.Size(315, 451);
            this.pickDetailPanel.TabIndex = 1;
            this.pickDetailPanel.Visible = false;
            // 
            // pickDetail
            // 
            this.pickDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickDetail.Location = new System.Drawing.Point(0, 259);
            this.pickDetail.Multiline = true;
            this.pickDetail.Name = "pickDetail";
            this.pickDetail.Size = new System.Drawing.Size(315, 130);
            this.pickDetail.TabIndex = 2;
            // 
            // pickLocation
            // 
            this.pickLocation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pickLocation.Location = new System.Drawing.Point(0, 389);
            this.pickLocation.Name = "pickLocation";
            this.pickLocation.Size = new System.Drawing.Size(315, 21);
            this.pickLocation.TabIndex = 4;
            // 
            // picksLowerPanel
            // 
            this.picksLowerPanel.Controls.Add(this.btnShowOnMap);
            this.picksLowerPanel.Controls.Add(this.btnTeleport);
            this.picksLowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picksLowerPanel.Location = new System.Drawing.Point(0, 410);
            this.picksLowerPanel.Name = "picksLowerPanel";
            this.picksLowerPanel.Size = new System.Drawing.Size(315, 41);
            this.picksLowerPanel.TabIndex = 3;
            // 
            // btnShowOnMap
            // 
            this.btnShowOnMap.Location = new System.Drawing.Point(87, 10);
            this.btnShowOnMap.Name = "btnShowOnMap";
            this.btnShowOnMap.Size = new System.Drawing.Size(98, 23);
            this.btnShowOnMap.TabIndex = 0;
            this.btnShowOnMap.Text = "Show on Map";
            this.btnShowOnMap.UseVisualStyleBackColor = true;
            this.btnShowOnMap.Click += new System.EventHandler(this.btnShowOnMap_Click);
            // 
            // btnTeleport
            // 
            this.btnTeleport.Location = new System.Drawing.Point(6, 10);
            this.btnTeleport.Name = "btnTeleport";
            this.btnTeleport.Size = new System.Drawing.Size(75, 23);
            this.btnTeleport.TabIndex = 0;
            this.btnTeleport.Text = "Teleport";
            this.btnTeleport.UseVisualStyleBackColor = true;
            this.btnTeleport.Click += new System.EventHandler(this.btnTeleport_Click);
            // 
            // pickTitle
            // 
            this.pickTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickTitle.Location = new System.Drawing.Point(0, 238);
            this.pickTitle.Name = "pickTitle";
            this.pickTitle.Size = new System.Drawing.Size(315, 21);
            this.pickTitle.TabIndex = 1;
            // 
            // pickPicturePanel
            // 
            this.pickPicturePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickPicturePanel.Location = new System.Drawing.Point(0, 0);
            this.pickPicturePanel.Name = "pickPicturePanel";
            this.pickPicturePanel.Size = new System.Drawing.Size(315, 238);
            this.pickPicturePanel.TabIndex = 0;
            // 
            // pickListPanel
            // 
            this.pickListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pickListPanel.Location = new System.Drawing.Point(3, 3);
            this.pickListPanel.Name = "pickListPanel";
            this.pickListPanel.Size = new System.Drawing.Size(139, 451);
            this.pickListPanel.TabIndex = 0;
            // 
            // tpgFirstLife
            // 
            this.tpgFirstLife.Controls.Add(this.rlPicPanel);
            this.tpgFirstLife.Controls.Add(this.rtbAboutFL);
            this.tpgFirstLife.Controls.Add(this.label8);
            this.tpgFirstLife.Controls.Add(this.label7);
            this.tpgFirstLife.Location = new System.Drawing.Point(4, 22);
            this.tpgFirstLife.Name = "tpgFirstLife";
            this.tpgFirstLife.Padding = new System.Windows.Forms.Padding(3);
            this.tpgFirstLife.Size = new System.Drawing.Size(460, 457);
            this.tpgFirstLife.TabIndex = 2;
            this.tpgFirstLife.Text = "First Life";
            this.tpgFirstLife.UseVisualStyleBackColor = true;
            // 
            // rlPicPanel
            // 
            this.rlPicPanel.Location = new System.Drawing.Point(6, 22);
            this.rlPicPanel.Name = "rlPicPanel";
            this.rlPicPanel.Size = new System.Drawing.Size(245, 163);
            this.rlPicPanel.TabIndex = 15;
            // 
            // rtbAboutFL
            // 
            this.rtbAboutFL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAboutFL.Location = new System.Drawing.Point(6, 201);
            this.rtbAboutFL.Name = "rtbAboutFL";
            this.rtbAboutFL.ReadOnly = true;
            this.rtbAboutFL.Size = new System.Drawing.Size(448, 150);
            this.rtbAboutFL.TabIndex = 14;
            this.rtbAboutFL.Text = "";
            this.rtbAboutFL.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbAboutFL_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "My first life pic:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "About my first life:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(405, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(18, 503);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(360, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Drop items from inventory here";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 536);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabProfile);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfile";
            this.Text = "Profile";
            this.tabProfile.ResumeLayout(false);
            this.tpgProfile.ResumeLayout(false);
            this.tpgProfile.PerformLayout();
            this.tpgWeb.ResumeLayout(false);
            this.tpgWeb.PerformLayout();
            this.tbpPicks.ResumeLayout(false);
            this.pickDetailPanel.ResumeLayout(false);
            this.pickDetailPanel.PerformLayout();
            this.picksLowerPanel.ResumeLayout(false);
            this.tpgFirstLife.ResumeLayout(false);
            this.tpgFirstLife.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tabProfile;
        public System.Windows.Forms.TabPage tpgProfile;
        public System.Windows.Forms.TabPage tpgWeb;
        public System.Windows.Forms.TabPage tpgFirstLife;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtFullName;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBornOn;
        public System.Windows.Forms.TextBox txtPartner;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Panel pnlWeb;
        public System.Windows.Forms.Button btnWebOpen;
        public System.Windows.Forms.Button btnWebView;
        public System.Windows.Forms.TextBox txtWebURL;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.RichTextBox rtbAbout;
        public System.Windows.Forms.RichTextBox rtbAboutFL;
        public System.Windows.Forms.RichTextBox rtbAccountInfo;
        public System.Windows.Forms.Button btnPay;
        public System.Windows.Forms.Button btnOfferTeleport;
        public System.Windows.Forms.Panel slPicPanel;
        public System.Windows.Forms.Panel rlPicPanel;
        public System.Windows.Forms.TabPage tbpPicks;
        public System.Windows.Forms.Panel pickDetailPanel;
        public System.Windows.Forms.Panel picksLowerPanel;
        public System.Windows.Forms.TextBox pickDetail;
        public System.Windows.Forms.TextBox pickTitle;
        public System.Windows.Forms.Panel pickPicturePanel;
        public System.Windows.Forms.Panel pickListPanel;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtUUID;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnFriend;
        public System.Windows.Forms.Button btnIM;
        public System.Windows.Forms.TextBox pickLocation;
        public System.Windows.Forms.Button btnShowOnMap;
        public System.Windows.Forms.Button btnTeleport;

    }
}