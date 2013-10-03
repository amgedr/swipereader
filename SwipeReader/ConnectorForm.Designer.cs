namespace SwipeReader
{
    partial class ConnectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectorForm));
            this.cardReader = new Axzkemkeeper.AxCZKEM();
            ((System.ComponentModel.ISupportInitialize)(this.cardReader)).BeginInit();
            this.SuspendLayout();
            // 
            // cardReader
            // 
            this.cardReader.Enabled = true;
            this.cardReader.Location = new System.Drawing.Point(12, 12);
            this.cardReader.Name = "cardReader";
            this.cardReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cardReader.OcxState")));
            this.cardReader.Size = new System.Drawing.Size(63, 49);
            this.cardReader.TabIndex = 16;
            this.cardReader.OnAttTransaction += new Axzkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(this.cardReader_OnAttTransaction);
            this.cardReader.OnKeyPress += new Axzkemkeeper._IZKEMEvents_OnKeyPressEventHandler(this.cardReader_OnKeyPress);
            this.cardReader.OnEnrollFinger += new Axzkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(this.cardReader_OnEnrollFinger);
            this.cardReader.OnNewUser += new Axzkemkeeper._IZKEMEvents_OnNewUserEventHandler(this.cardReader_OnNewUser);
            this.cardReader.OnEMData += new Axzkemkeeper._IZKEMEvents_OnEMDataEventHandler(this.cardReader_OnEMData);
            this.cardReader.OnConnected += new System.EventHandler(this.cardReader_OnConnected);
            this.cardReader.OnDisConnected += new System.EventHandler(this.cardReader_OnDisConnected);
            this.cardReader.OnFinger += new System.EventHandler(this.cardReader_OnFinger);
            this.cardReader.OnVerify += new Axzkemkeeper._IZKEMEvents_OnVerifyEventHandler(this.cardReader_OnVerify);
            this.cardReader.OnFingerFeature += new Axzkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(this.cardReader_OnFingerFeature);
            this.cardReader.OnHIDNum += new Axzkemkeeper._IZKEMEvents_OnHIDNumEventHandler(this.cardReader_OnHIDNum);
            this.cardReader.OnDoor += new Axzkemkeeper._IZKEMEvents_OnDoorEventHandler(this.cardReader_OnDoor);
            this.cardReader.OnWriteCard += new Axzkemkeeper._IZKEMEvents_OnWriteCardEventHandler(this.cardReader_OnWriteCard);
            this.cardReader.OnEmptyCard += new Axzkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(this.cardReader_OnEmptyCard);
            this.cardReader.OnAttTransactionEx += new Axzkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(this.cardReader_OnAttTransactionEx);
            this.cardReader.OnEnrollFingerEx += new Axzkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(this.cardReader_OnEnrollFingerEx);
            // 
            // ConnectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 132);
            this.Controls.Add(this.cardReader);
            this.Name = "ConnectorForm";
            this.Text = "ConnectorForm";
            ((System.ComponentModel.ISupportInitialize)(this.cardReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Axzkemkeeper.AxCZKEM cardReader;

    }
}