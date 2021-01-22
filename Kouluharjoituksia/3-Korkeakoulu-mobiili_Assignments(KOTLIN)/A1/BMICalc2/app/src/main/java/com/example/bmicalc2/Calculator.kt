package com.example.bmicalc2

import android.content.Context
import android.content.SharedPreferences
import android.util.Log
import androidx.preference.PreferenceManager
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import java.lang.Math.pow
import java.util.*

public var BMIMapCategories:List<Triple<Float,Float,String>>?= listOf(Triple(0f,15f, "Very severely underweight"), Triple(15f,16f, "Severely underweight"),
        Triple(16f,18.5f, "Underweight"), Triple(18.5f, 25f, "Normal weight"), Triple(25f,30f, "Overweight"),
        Triple(30f,35f,"Moderately obese" ), Triple(35f, 40f, "Severely obese"), Triple(40f, Float.POSITIVE_INFINITY, "Very severely obese"))
public var BMILIstCalculated:MutableList<BMICalculation>?= mutableListOf<BMICalculation>()

public fun storeBMI(context: Context, weight: String?)
    {

        val weightFloat = weight?.toFloat()
        val shared: SharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
        val channel = shared.getString("UserHeight", "DEFAULT")
        val floatOfHeight = channel?.toFloat()
        BMILIstCalculated = getSavedBMIList(context)
        BMILIstCalculated?.add(calculateBMI(weightFloat, floatOfHeight))
        for (item in BMILIstCalculated!!)
        {
            Log.d("Item", item.CategoryOfBMI())
            Log.d("Item", item.BMI.toString())
        }
        saveBMIList(BMILIstCalculated!!, context)

    }

public fun calculateBMI(nWeight:Float?, nHeight:Float?):BMICalculation {
    val heightInMetresSquared =  pow(nHeight?.div(100f)!!.toDouble(), 2.0)
    val calcBMI = (nWeight!! /heightInMetresSquared).toFloat()
    val bmiCalc = BMICalculation(nWeight, calcBMI, Calendar.getInstance().time)
    return bmiCalc
}
class BMICalculation(cWeight:Float?, cBMI:Float?, cDate: Date){
    val Weight:Float?=cWeight
    val BMI:Float?=cBMI
    val DateOfCalculation:Date?=cDate
    fun CategoryOfBMI() : String
    {
        val categoryFound =  BMIMapCategories.orEmpty().firstOrNull() {
            BMI!! > it.first && BMI!! < it.second
        }
        return categoryFound!!.third
    }
}
fun saveBMIList(listToSave:MutableList<BMICalculation>, context: Context)
{
    val shared: SharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
    val editor = shared.edit()
    val gson = Gson()
    val jsonFile = gson.toJson(listToSave)
    editor.putString("BMIList", jsonFile)
    editor.commit()

}
fun getSavedBMIList(context: Context):MutableList<BMICalculation>
{
    val gson = Gson()
    val shared: SharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
    val jsonFile = shared.getString("BMIList", null)
    val type = object : TypeToken<MutableList<BMICalculation>>(){}.type
    return gson.fromJson(jsonFile, type) ?: mutableListOf<BMICalculation>()
    //Kys. returnissa on tsekki että löytyykö kys. listaa. Jos ei, palauta empty lista.
}
