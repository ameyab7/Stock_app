namespace COP_4365_002_Spring_2024_Demo
{
    partial class Form_StockViewer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_pickastock = new System.Windows.Forms.Button();
            this.openFileDialog_TickerChooser = new System.Windows.Forms.OpenFileDialog();
            this.candlestickBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chartCandlestick = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.Pattern_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCandlestick)).BeginInit();
            this.SuspendLayout();
            // 
            // button_pickastock
            // 
            this.button_pickastock.Location = new System.Drawing.Point(777, 64);
            this.button_pickastock.Name = "button_pickastock";
            this.button_pickastock.Size = new System.Drawing.Size(175, 85);
            this.button_pickastock.TabIndex = 0;
            this.button_pickastock.Text = "pick a stock";
            this.button_pickastock.UseVisualStyleBackColor = true;
            this.button_pickastock.Click += new System.EventHandler(this.button_pickastock_Click);
            // 
            // openFileDialog_TickerChooser
            // 
            this.openFileDialog_TickerChooser.FileName = "openFileDialog1";
            this.openFileDialog_TickerChooser.Multiselect = true;
            this.openFileDialog_TickerChooser.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_TickerChooser_FileOk);
            // 
            // chartCandlestick
            // 
            chartArea7.AlignWithChartArea = "ChartArea_vol";
            chartArea7.Name = "ChartArea_OHLC";
            chartArea8.Name = "ChartArea_vol";
            this.chartCandlestick.ChartAreas.Add(chartArea7);
            this.chartCandlestick.ChartAreas.Add(chartArea8);
            this.chartCandlestick.Location = new System.Drawing.Point(39, 298);
            this.chartCandlestick.Margin = new System.Windows.Forms.Padding(0);
            this.chartCandlestick.Name = "chartCandlestick";
            series7.ChartArea = "ChartArea_OHLC";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series7.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series7.IsXValueIndexed = true;
            series7.Name = "Series_OLHC";
            series7.XValueMember = "date";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series7.YValueMembers = "high,low,open,close";
            series7.YValuesPerPoint = 4;
            series8.ChartArea = "ChartArea_vol";
            series8.IsXValueIndexed = true;
            series8.Name = "Series2_Vol";
            series8.XValueMember = "date";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series8.YValueMembers = "volume";
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chartCandlestick.Series.Add(series7);
            this.chartCandlestick.Series.Add(series8);
            this.chartCandlestick.Size = new System.Drawing.Size(2561, 880);
            this.chartCandlestick.TabIndex = 2;
            this.chartCandlestick.Text = "chart1";
            this.chartCandlestick.AnnotationTextChanged += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            this.chartCandlestick.AnnotationSelectionChanged += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            this.chartCandlestick.AnnotationPositionChanged += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            this.chartCandlestick.AnnotationPlaced += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(777, 26);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(412, 31);
            this.startDatePicker.TabIndex = 3;
            this.startDatePicker.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(784, 172);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(362, 31);
            this.endDatePicker.TabIndex = 4;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(958, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 68);
            this.button2.TabIndex = 5;
            this.button2.Text = "Update\r\n\r\n\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_update);
            // 
            // Pattern_comboBox
            // 
            this.Pattern_comboBox.FormattingEnabled = true;
            this.Pattern_comboBox.Location = new System.Drawing.Point(1315, 91);
            this.Pattern_comboBox.Name = "Pattern_comboBox";
            this.Pattern_comboBox.Size = new System.Drawing.Size(291, 33);
            this.Pattern_comboBox.TabIndex = 6;
            this.Pattern_comboBox.SelectedIndexChanged += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            this.Pattern_comboBox.Click += new System.EventHandler(this.Pattern_comboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1375, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pattern Selector";
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2636, 1208);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pattern_comboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.chartCandlestick);
            this.Controls.Add(this.button_pickastock);
            this.Name = "Form_StockViewer";
            this.Text = "Please Pick A Stock";
            this.Load += new System.EventHandler(this.Form_StockViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCandlestick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_pickastock;
        private System.Windows.Forms.OpenFileDialog openFileDialog_TickerChooser;
       
        private System.Windows.Forms.BindingSource candlestickBindingSource1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCandlestick;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox Pattern_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

