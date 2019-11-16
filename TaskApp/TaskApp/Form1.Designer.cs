namespace TaskApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.listDatas = new System.Windows.Forms.ListBox();
            this.comboSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(43, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(155, 51);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始采集";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(607, 24);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(131, 51);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "结束采集";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // listDatas
            // 
            this.listDatas.FormattingEnabled = true;
            this.listDatas.ItemHeight = 15;
            this.listDatas.Location = new System.Drawing.Point(43, 108);
            this.listDatas.Name = "listDatas";
            this.listDatas.Size = new System.Drawing.Size(695, 319);
            this.listDatas.TabIndex = 2;
            // 
            // comboSelect
            // 
            this.comboSelect.FormattingEnabled = true;
            this.comboSelect.Items.AddRange(new object[] {
            "京东",
            "淘宝",
            "苏宁"});
            this.comboSelect.Location = new System.Drawing.Point(454, 24);
            this.comboSelect.Name = "comboSelect";
            this.comboSelect.Size = new System.Drawing.Size(134, 23);
            this.comboSelect.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.comboSelect);
            this.Controls.Add(this.listDatas);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.ListBox listDatas;
        private System.Windows.Forms.ComboBox comboSelect;
    }
}

