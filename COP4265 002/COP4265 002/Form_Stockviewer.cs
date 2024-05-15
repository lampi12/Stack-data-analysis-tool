using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;

namespace COP4265_002
{
    public partial class Form_Stockviewer : Form
    {
        // List to hold all the Smartcandlesticks read from the file
        List<SmartCandlestick> listOfCandlesticks = new List<SmartCandlestick>();
        // BindingList to store Smartcandlesticks for data binding
        BindingList<SmartCandlestick> BindinglistOfCandlesticks = new BindingList<SmartCandlestick>();
        // List to store recognizers for candlestick patterns 
        private List<Recognizer> recognizers;

        public Form_Stockviewer()
        {
            InitializeComponent();
        }

        private void InitializeSmartCandlestickComboBox()
        {
            // Clear existing items in the combo box 
            comboBox_Smartpatterns.Items.Clear();

            // Initialize recognizers list with various candlestick pattern recognizers
            recognizers = new List<Recognizer>();
            // Add bullish pattern name to recognizer
            recognizers.Add(new Recognizer_Bullish());
            // Add bearish pattern name to recognizer
            recognizers.Add(new Recognizer_Bearish());
            // Add neutral pattern name to recognizer
            recognizers.Add(new Recognizer_Neutral());
            // Add doji pattern name to recognizer
            recognizers.Add(new Recognizer_Doji());
            // Add dragon fly doji pattern name to recognizer
            recognizers.Add(new Recognizer_DragonFlyDoji());
            // Add gravestone doji pattern name to recognizer
            recognizers.Add(new Recognizer_GravestoneDoji());
            // Add marubozu pattern name to recognizer
            recognizers.Add(new Recognizer_Marubouzu());
            // Add hammer pattern name to recognizer
            recognizers.Add(new Recognizer_Hammer());
            // Add bullish engulf pattern name to recognizer
            recognizers.Add(new Recognizer_BullishEngulfing());
            // Add bearish engulf pattern name to recognizer
            recognizers.Add(new Recognizer_BearishEngulfing());
            // Add peak pattern name to recognizer
            recognizers.Add(new Recognizer_Peak());
            // Add valley pattern name to recognizer
            recognizers.Add(new Recognizer_Valley());
            // Add bearish harami pattern name to recognizer
            recognizers.Add(new Recognizer_BearishHarami());
            // Add bullish harami pattern name to recognizer
            recognizers.Add(new Recognizer_BullishHarami());
            // Add all the pattern names to combo box
            foreach (Recognizer r in recognizers)
            {
                //Itterate over the recognizers and add the patternames to the combo box 
                comboBox_Smartpatterns.Items.Add(r.patternName);
            }

            // Subscribe to the SelectedIndexChanged event
            comboBox_Smartpatterns.SelectedIndexChanged += comboBox_Smartcandlestick;
        }

        private void button_loadStock(object sender, EventArgs e)
        {
            // Show the file dialog to select a stock file
            openFileDialog_stockPicker.ShowDialog();
        }

        private void openFileDialog_StockChooser_Fileok(object sender, CancelEventArgs e)
        {
            // Loop through each selected file in the OpenFileDialog
            foreach (string f in openFileDialog_stockPicker.FileNames)
            {
                // Create a new instance of Form_Stockviewer for each file
                Form_Stockviewer stockviewer = new Form_Stockviewer();
            }

            // Get the start and end dates selected in the DateTimePicker controls
            DateTime startdate = dateTimePicker_startDate.Value;
            DateTime enddate = dateTimePicker_endDate.Value;

            // Get the number of selected files
            int numoffiles = openFileDialog_stockPicker.FileNames.Count();

            // Loop through each selected file
            for (int i = 0; i < numoffiles; i++)
            {
                // Get the path name of the current file
                string pathName = openFileDialog_stockPicker.FileNames[i];
                // Extract the file name without extension
                string chooser = Path.GetFileNameWithoutExtension(pathName);

                // Declare a Form_Stockviewer variable to hold the form to be viewed 
                Form_Stockviewer form_Stockviewer;
                // Check if it's the first file
                if (i == 0)
                {
                    // If it's the first file, use the current form for viewing
                    form_Stockviewer = this;
                    // Perform necessary operations on the current form
                    goReadFile();
                    filtercandlesticks();
                    InitializeSmartCandlestickComboBox();
                    displayCandlesticks();
                    normalizechart();
                    displayChart();
                    // Set the title of the current form
                    form_Stockviewer.Text = "Parent: " + chooser;
                }
                else
                {
                    // If it's not the first file, instantiate a new form for viewing
                    form_Stockviewer = new Form_Stockviewer(pathName, startdate, enddate);
                    // Set the title of the new form
                    form_Stockviewer.Text = "Child: " + chooser;
                }

                //Display new form
                form_Stockviewer.Show();
                // Bring the form to the front
                form_Stockviewer.BringToFront();
            }
        }

        /// <summary>
        /// Constructor of Form_Stockviewer class with parameters for stock path, start date, and end date
        /// </summary>
        /// <param name="stockpath"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Form_Stockviewer(string stockpath, DateTime start, DateTime end)
        {
            // Initialize the form components
            InitializeComponent();
            // Initialize the ComboBox for smart candlestick selection
            InitializeSmartCandlestickComboBox();

            // Set the start and end dates in the DateTimePicker controls
            dateTimePicker_startDate.Value = start;
            dateTimePicker_endDate.Value = end;

            // Read the file and store the list of candlesticks
            listOfCandlesticks = goReadFile(stockpath);
            // Filter the candlesticks based on selected dates
            filtercandlesticks();
            // Display the candlesticks on the form
            displayCandlesticks();
            // Normalize the chart
            normalizechart();
            // Display the chart
            displayChart();
        }

        /// <summary>
        /// Read the selected file and populate the listOfCandlesticks
        /// Does not return anything
        /// </summary>
        private void goReadFile()
        {
            // Call function to read the selected file and output it to a listofcandlesticks
            listOfCandlesticks = goReadFile(openFileDialog_stockPicker.FileName);
        }

        /// <summary>
        /// Read the file and convert data into candlesticks
        /// This Function will convert the data input from a csv file into candlesticks
        /// </summary>
        /// <param name="filename">
        /// It takes in a string that holds the file name of the file to be read 
        /// </param>
        /// <returns>
        /// It returns a list of candlesticks read from the selected file
        /// </returns>
        private List<SmartCandlestick> goReadFile(string filename)
        {
            //const string referencestring = "Date,Open,High,Low,Close,Adj Close,Volume";
            List<SmartCandlestick> resultList = new List<SmartCandlestick>(1024);

            //Pass the file path and filename to the Stream reader constructor 
            using (StreamReader sr = new StreamReader(filename))
            {
                // Read the header line
                string line = sr.ReadLine();
                //continue to read until you reach end of file
                while ((line = sr.ReadLine()) != null)
                {
                    //Read the next line
                    //This is where we need to instantiate the candlestick represented by the string  
                    SmartCandlestick cs = new SmartCandlestick(line); // Create candlestick object from the line
                    resultList.Add(cs); // Add candlestick to the list
                }
            }
            return resultList; // Return list of candlesticks
        }

        /// <summary>
        /// Filter candlesticks based on start and end date
        /// Stores only the candlesticks we want from the read data
        /// </summary>
        /// <param name="Candlestickslist">
        /// It takes in a list of candlesticks that was read from the selected file 
        /// </param>
        /// <param name="startDate">
        /// Takes in the value of the prefered start date for the filter
        /// </param>
        /// <param name="endDate">
        /// Takes in the value of the prefered end date for the filter 
        /// </param>
        /// <returns> It returns a list of filtered candlesticks from the prefered startdate to the enddate</returns>
        private List<SmartCandlestick> filterCandlesticks(List<SmartCandlestick> Candlestickslist, DateTime startDate, DateTime endDate)
        {
            //Create a list of candlesticks 
            List<SmartCandlestick> selectedCandlesticks = new List<SmartCandlestick>();
            // Loop over each candlestick in the listofcandlesticks
            foreach (SmartCandlestick cs in Candlestickslist)
            {
                //If we have not reached the start date yet, go to the next candlestick
                if (cs.date < startDate)
                    continue;
                //If we have passed the ending date, we are done
                if (cs.date > endDate)
                    break;
                //At this point we are in the right range so we just add to the bounding list
                selectedCandlesticks.Add(cs);
            }
            return selectedCandlesticks; // Return filtered candlesticks
        }

        /// <summary>
        /// This function is the helper function for the filterCandlesticks function.
        /// It calls the parent function which return a list of candlesticks, with the filter range values from the datetime picker and a list of all the candlestick.
        /// It then stores the values of the filteredList into a BindingList.
        /// </summary>
        private void filtercandlesticks()
        {
            //Start date values from the datetime picker 
            DateTime startDate = dateTimePicker_startDate.Value.Date;
            //End date values from the datetime picker
            DateTime endDate = dateTimePicker_endDate.Value.Date;
            //Create a new list to store the filtered cnadlesticks from the parent function
            List<SmartCandlestick> filteredlist = filterCandlesticks(listOfCandlesticks, startDate, endDate);
            //CLear previous values in the BindingList
            BindinglistOfCandlesticks.Clear();
            //Copy values of the filtered list into the BindingList
            BindinglistOfCandlesticks = new BindingList<SmartCandlestick>(filteredlist);
        }

        /// <summary>
        /// Normalizes chart properties by setting minimum and maximum values of chart area and sets the Y value members so it displays properly
        /// </summary>
        private void normalizechart()
        {
            //Check if the BindingList is not null or empty to continue
            if (BindinglistOfCandlesticks != null && BindinglistOfCandlesticks.Count > 0)
            {
                //Set series Y value member
                chart_Candlesticks.Series["OHLC"].YValueMembers = "high, low, open, close";

                //Set chart area properties 
                chart_Candlesticks.ChartAreas["ChartArea_OHLC"].AxisY.Minimum =
                    0.98 * (double)Math.Floor((BindinglistOfCandlesticks.Min(c => c.low)));// Adjust minimum for better visulization 
                chart_Candlesticks.ChartAreas["ChartArea_OHLC"].AxisY.Maximum =
                    1.02 * (double)Math.Ceiling(BindinglistOfCandlesticks.Max(c => c.high));// Adjust minimum for better visulization
            }
        }

        /// <summary>
        /// Display the chart with normalized axis by giving it an accurate list as its datasource and binding the data to the chart 
        /// </summary>
        private void displayChart()
        {
            //Now bind the chart to the bindindList of candlesticks
            chart_Candlesticks.DataSource = BindinglistOfCandlesticks;
            //Make the databinding availiable to the chart
            chart_Candlesticks.DataBind();
        }

        /// <summary>
        /// Display filtered candlesticks in DataGridView
        /// The the data grid view gets the correct list as a datasource 
        /// </summary>
        private void displayCandlesticks()
        {
            //Create a new Bindinglist to store the filtered candlesticks to be displayed
            BindingList<SmartCandlestick> Boundlist = new BindingList<SmartCandlestick>(BindinglistOfCandlesticks);
        }

        /// <summary>
        /// Update candlesticks data when new start or end data have been selected 
        /// Calls the required functions in the right order 
        /// </summary>
        private void update()
        {
            // Clear any existing chart annotations
            ClearChartAnnotations();

            // Check if an item is selected in the comboBox_Smartpatterns
            if (comboBox_Smartpatterns.SelectedItem != null)
            {
                // Get the selected pattern as a string
                string selectedPattern = comboBox_Smartpatterns.SelectedItem.ToString();
                // Check if the selected pattern is not null or empty
                if (!string.IsNullOrEmpty(selectedPattern))
                {
                    // Detect and annotate the selected pattern on the chart
                    DetectAndAnnotatePattern(selectedPattern);
                }
            }
            // Filter candlesticks based on the desired date range
            filtercandlesticks();

            // Display updated data in the DataGridView
            displayCandlesticks();

            // Set minimum and maximum values of the chart area and set the Y value members for proper display
            normalizechart();

            // Display updated data on the chart
            displayChart();
        }

        /// <summary>
        /// Event handler for the button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update(object sender, EventArgs e)
        {
            // Call the update function when the button is clicked
            update();
        }

        /// <summary>
        /// Event handler for the comboBox_Smartcandlestick selection change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Smartcandlestick(object sender, EventArgs e)
        {
            // Clear any existing chart annotations
            ClearChartAnnotations();

            // Check if an item is selected in the comboBox_Smartpatterns
            if (comboBox_Smartpatterns.SelectedItem != null)
            {
                // Get the selected pattern as a string
                string selectedPattern = comboBox_Smartpatterns.SelectedItem.ToString();
                // Check if the selected pattern is not null or empty
                if (!string.IsNullOrEmpty(selectedPattern))
                {
                    // Detect and annotate the selected pattern on the chart
                    DetectAndAnnotatePattern(selectedPattern);
                }
            }
        }

        /// <summary>
        /// Function to clear the annotations from the chart 
        /// </summary>
        private void ClearChartAnnotations()
        {
            // Clear the annotations on the chart
            chart_Candlesticks.Annotations.Clear();
        }

        /// <summary>
        /// Function that detects the selected pattern and call the add annotation function 
        /// </summary>
        /// <param name="pattern"></param>
        private void DetectAndAnnotatePattern(string pattern)
        {
            // Loop through each candlestick
            for (int i = 0; i < BindinglistOfCandlesticks.Count; i++)
            {
                // Iterate through each recognizer
                foreach (Recognizer recognizer in recognizers)
                {
                    if (recognizer.patternName == pattern)
                    {
                        //Call the Recognize method of the recognizer
                        if (recognizer.Recognize(BindinglistOfCandlesticks, i))
                        {
                            // If pattern is detected, add annotation to the chart
                            AddRectangleAnnotation(BindinglistOfCandlesticks[i].date, recognizer.patternName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Function that adds the Rectancgle annotation to the chart
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pattern"></param>
        private void AddRectangleAnnotation(DateTime date, string pattern)
        {
            // Loop through the list of candlesticks
            for (int i = 0; i < BindinglistOfCandlesticks.Count; i++)
            {
                // Check if the date of the current candlestick matches the specified date
                if (BindinglistOfCandlesticks[i].date.Date == date.Date)
                {
                    // Determine color and type based on the detected pattern
                    Color annotationColor;
                    string candlestickType;

                    // Checking if selected patterns match a certain pattern then adds a color and Candlestick type
                    if (pattern == "Bullish")
                    {
                        annotationColor = Color.Blue;
                        candlestickType = "Bullish";
                    }
                    else if (pattern == "Bearish")
                    {
                        annotationColor = Color.Black;
                        candlestickType = "Bearish";
                    }
                    else if (pattern == "Doji")
                    {
                        annotationColor = Color.Gray;
                        candlestickType = "Doji";
                    }
                    else if (pattern == "Marubouzu")
                    {
                        annotationColor = Color.Purple;
                        candlestickType = "Marubouzu";
                    }
                    else if (pattern == "DragonFlyDoji")
                    {
                        annotationColor = Color.Green;
                        candlestickType = "Dragonfly Doji";
                    }
                    else if (pattern == "GravestoneDoji")
                    {
                        annotationColor = Color.Red;
                        candlestickType = "Gravestone Doji";
                    }
                    else if (pattern == "Hammer")
                    {
                        annotationColor = Color.Orange;
                        candlestickType = "Hammer";
                    }
                    else if (pattern == "Neutral")
                    {
                        annotationColor = Color.ForestGreen;
                        candlestickType = "Neutral";
                    }
                    else if (pattern == "BearishEngulfing")
                    {
                        annotationColor = Color.BurlyWood;
                        candlestickType = "BearishEngulfing";
                    }
                    else if (pattern == "BearishHarami")
                    {
                        annotationColor = Color.Gold;
                        candlestickType = "BearishHarami";
                    }
                    else if (pattern == "BullishEngulfing")
                    {
                        annotationColor = Color.Coral;
                        candlestickType = "BullishEngulfing";
                    }
                    else if (pattern == "BullishHarami")
                    {
                        annotationColor = Color.DarkTurquoise;
                        candlestickType = "BullishHarami";
                    }
                    else if (pattern == "Peak")
                    {
                        annotationColor = Color.Orange;
                        candlestickType = "Peak";
                    }
                    else if (pattern == "Valley")
                    {
                        annotationColor = Color.DarkViolet;
                        candlestickType = "Valley";
                    }
                    else
                    {
                        // If pattern is not recognized, return without adding annotation
                        return;
                    }

                    // Create and add annotation
                    double x = i + 1;
                    double y = (double)(BindinglistOfCandlesticks[i].high);

                    // Create a new RectangleAnnotation object
                    RectangleAnnotation annotation = new RectangleAnnotation();
                    // Set the anchor data point for the annotation
                    annotation.AnchorDataPoint = chart_Candlesticks.Series["OHLC"].Points[i];
                    annotation.AnchorX = x;
                    annotation.AnchorY = y;
                    annotation.Height = 4; // Customize as needed
                    annotation.Width = 6; // Customize as needed
                    annotation.Text = candlestickType; // Set the text of the annotation
                    annotation.BackColor = annotationColor; // Set annotation color
                    annotation.ForeColor = Color.White; // Set text color

                    annotation.LineWidth = 0; // Set line width to 0
                    annotation.Alignment = ContentAlignment.TopCenter; // Set text alignment

                    // Add the annotation to the chart
                    chart_Candlesticks.Annotations.Add(annotation);

                    // Exit the loop after adding the annotation
                    break;
                }
            }
        }

    }       
}
