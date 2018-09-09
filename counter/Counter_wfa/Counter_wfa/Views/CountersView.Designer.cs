namespace Counter_wfa.Views
{
    partial class CountersView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._countersListBox = new System.Windows.Forms.ListBox();
            this._addNewCounterButton = new System.Windows.Forms.Button();
            this._newCounterNameTextBox = new System.Windows.Forms.TextBox();
            this._incrementButton = new System.Windows.Forms.Button();
            this._decrementButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _countersListBox
            // 
            this._countersListBox.FormattingEnabled = true;
            this._countersListBox.ItemHeight = 12;
            this._countersListBox.Location = new System.Drawing.Point(12, 12);
            this._countersListBox.Name = "_countersListBox";
            this._countersListBox.Size = new System.Drawing.Size(276, 424);
            this._countersListBox.TabIndex = 0;
            // 
            // _addNewCounterButton
            // 
            this._addNewCounterButton.Location = new System.Drawing.Point(413, 415);
            this._addNewCounterButton.Name = "_addNewCounterButton";
            this._addNewCounterButton.Size = new System.Drawing.Size(75, 23);
            this._addNewCounterButton.TabIndex = 1;
            this._addNewCounterButton.Text = "button1";
            this._addNewCounterButton.UseVisualStyleBackColor = true;
            // 
            // _newCounterNameTextBox
            // 
            this._newCounterNameTextBox.Location = new System.Drawing.Point(307, 415);
            this._newCounterNameTextBox.Name = "_newCounterNameTextBox";
            this._newCounterNameTextBox.Size = new System.Drawing.Size(100, 19);
            this._newCounterNameTextBox.TabIndex = 2;
            // 
            // _incrementButton
            // 
            this._incrementButton.Location = new System.Drawing.Point(294, 12);
            this._incrementButton.Name = "_incrementButton";
            this._incrementButton.Size = new System.Drawing.Size(23, 23);
            this._incrementButton.TabIndex = 3;
            this._incrementButton.Text = "+";
            this._incrementButton.UseVisualStyleBackColor = true;
            // 
            // _decrementButton
            // 
            this._decrementButton.Location = new System.Drawing.Point(330, 12);
            this._decrementButton.Name = "_decrementButton";
            this._decrementButton.Size = new System.Drawing.Size(22, 23);
            this._decrementButton.TabIndex = 4;
            this._decrementButton.Text = "-";
            this._decrementButton.UseVisualStyleBackColor = true;
            // 
            // CountersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this._decrementButton);
            this.Controls.Add(this._incrementButton);
            this.Controls.Add(this._newCounterNameTextBox);
            this.Controls.Add(this._addNewCounterButton);
            this.Controls.Add(this._countersListBox);
            this.Name = "CountersView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _countersListBox;
        private System.Windows.Forms.Button _addNewCounterButton;
        private System.Windows.Forms.TextBox _newCounterNameTextBox;
        private System.Windows.Forms.Button _incrementButton;
        private System.Windows.Forms.Button _decrementButton;
    }
}

