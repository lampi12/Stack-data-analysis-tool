namespace COP4265_002
{
    partial class Form_Stockviewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_loadStockdata = new System.Windows.Forms.Button();
            this.openFileDialog_stockPicker = new System.Windows.Forms.OpenFileDialog();
            this.chart_Candlesticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.candlestickBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.button_update = new System.Windows.Forms.Button();
            this.StartDate = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.Label();
            this.comboBox_Smartpatterns = new System.Windows.Forms.ComboBox();
            this.Smartcandlestickbindingsource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Candlesticks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Smartcandlestickbindingsource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_loadStockdata
            // 
            this.button_loadStockdata.Location = new System.Drawing.Point(462, 12);
            this.button_loadStockdata.Name = "button_loadStockdata";
            this.button_loadStockdata.Size = new System.Drawing.Size(124, 46);
            this.button_loadStockdata.TabIndex = 0;
            this.button_loadStockdata.Text = "Pick a stock";
            this.button_loadStockdata.UseVisualStyleBackColor = true;
            this.button_loadStockdata.Click += new System.EventHandler(this.button_loadStock);
            // 
            // openFileDialog_stockPicker
            // 
            this.openFileDialog_stockPicker.Multiselect = true;
            this.openFileDialog_stockPicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_StockChooser_Fileok);
            // 
            // chart_Candlesticks
            // 
            chartArea1.AlignWithChartArea = "ChartArea_VOLUME";
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_VOLUME";
            this.chart_Candlesticks.ChartAreas.Add(chartArea1);
            this.chart_Candlesticks.ChartAreas.Add(chartArea2);
            this.chart_Candlesticks.DataSource = this.candlestickBindingSource2;
            this.chart_Candlesticks.Location = new System.Drawing.Point(3, 139);
            this.chart_Candlesticks.Name = "chart_Candlesticks";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series1.IsXValueIndexed = true;
            series1.Name = "OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "open, high, low, close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea_VOLUME";
            series2.IsXValueIndexed = true;
            series2.Name = "Volume";
            series2.XValueMember = "date";
            series2.YValueMembers = "volume";
            series2.YValuesPerPoint = 4;
            this.chart_Candlesticks.Series.Add(series1);
            this.chart_Candlesticks.Series.Add(series2);
            this.chart_Candlesticks.Size = new System.Drawing.Size(1056, 469);
            this.chart_Candlesticks.TabIndex = 2;
            this.chart_Candlesticks.Text = "chart_Candlesticks";
            // 
            // candlestickBindingSource2
            // 
            this.candlestickBindingSource2.AllowNew = false;
            this.candlestickBindingSource2.DataSource = typeof(COP4265_002.Candlestick);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(12, 102);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(300, 22);
            this.dateTimePicker_startDate.TabIndex = 4;
            this.dateTimePicker_startDate.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(748, 102);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(300, 22);
            this.dateTimePicker_endDate.TabIndex = 5;
            this.dateTimePicker_endDate.Value = new System.DateTime(2023, 1, 8, 0, 0, 0, 0);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(478, 80);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(87, 44);
            this.button_update.TabIndex = 6;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_Update);
            // 
            // StartDate
            // 
            this.StartDate.AutoSize = true;
            this.StartDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartDate.Location = new System.Drawing.Point(12, 83);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(63, 16);
            this.StartDate.TabIndex = 7;
            this.StartDate.Text = "StartDate";
            // 
            // EndDate
            // 
            this.EndDate.AutoSize = true;
            this.EndDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EndDate.Location = new System.Drawing.Point(988, 83);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(60, 16);
            this.EndDate.TabIndex = 8;
            this.EndDate.Text = "EndDate";
            // 
            // comboBox_Smartpatterns
            // 
            this.comboBox_Smartpatterns.FormattingEnabled = true;
            this.comboBox_Smartpatterns.Location = new System.Drawing.Point(584, 102);
            this.comboBox_Smartpatterns.Name = "comboBox_Smartpatterns";
            this.comboBox_Smartpatterns.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Smartpatterns.TabIndex = 9;
            this.comboBox_Smartpatterns.SelectedIndexChanged += new System.EventHandler(this.comboBox_Smartcandlestick);
            // 
            // Smartcandlestickbindingsource
            // 
            this.Smartcandlestickbindingsource.DataSource = typeof(COP4265_002.SmartCandlestick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Pattern";
            // 
            // Form_Stockviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 620);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Smartpatterns);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.chart_Candlesticks);
            this.Controls.Add(this.button_loadStockdata);
            this.Name = "Form_Stockviewer";
            this.Text = "Form_stockloader";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Candlesticks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Smartcandlestickbindingsource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_loadStockdata;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockPicker;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Candlesticks;
        private System.Windows.Forms.BindingSource candlestickBindingSource2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label StartDate;
        private System.Windows.Forms.Label EndDate;
        private System.Windows.Forms.ComboBox comboBox_Smartpatterns;
        private System.Windows.Forms.BindingSource Smartcandlestickbindingsource;
        private System.Windows.Forms.Label label1;
    }
}

