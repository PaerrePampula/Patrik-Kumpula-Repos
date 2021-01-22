package com.example.bmicalc2

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.github.mikephil.charting.data.BarData
import com.github.mikephil.charting.data.BarDataSet
import com.github.mikephil.charting.data.BarEntry
import com.github.mikephil.charting.utils.ColorTemplate
import kotlinx.android.synthetic.main.activity_bar_graph.*
import java.util.*

class BarGraph : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_bar_graph)
        val savedList = getSavedBMIList(this.applicationContext)

        var entries = arrayListOf<BarEntry>()
        var labels = arrayListOf<String>()
        for (i in savedList.indices)
        {
            entries.add(BarEntry(savedList[i].BMI!!, i));
            var date = ""
            val c: Calendar = Calendar.getInstance()
            c.setTime(savedList[i].DateOfCalculation)
            date = c.get(Calendar.DAY_OF_WEEK).toString() + "-" + c.get(Calendar.MONTH) + "-" + c.get(Calendar.YEAR)
            val category = savedList[i].CategoryOfBMI()

            labels.add("$date. Class:$category");
        }
        var bardataset = BarDataSet(entries, "BMIs");

        var data =  BarData(labels, bardataset);
        barchart.setData(data); // set the data and list of labels into chart
        barchart.setDescription("User inputted BMIs");  // set the description
        bardataset.setColors(ColorTemplate.COLORFUL_COLORS);
        barchart.animateY(5000);



    }
}