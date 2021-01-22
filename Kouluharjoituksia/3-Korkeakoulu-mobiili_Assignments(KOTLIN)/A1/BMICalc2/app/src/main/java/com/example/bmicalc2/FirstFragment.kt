package com.example.bmicalc2

import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup

import androidx.navigation.fragment.findNavController
import androidx.preference.PreferenceManager
import com.google.android.material.snackbar.BaseTransientBottomBar
import com.google.android.material.snackbar.Snackbar
import kotlinx.android.synthetic.main.fragment_first.*

/**
 * A simple [Fragment] subclass as the default destination in the navigation.
 */
class FirstFragment : Fragment() {

    override fun onCreateView(

            inflater: LayoutInflater, container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_first, container, false)
    }
/* Tieto bmin määrästä tallentuu listaan calculator ktssa, tieto siitä löytyy logcatista*/
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        val shared: SharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
        val channel = shared.getString("UserHeight", "DEFAULT")
        var builtStringForHeightDesc = usr_height_desc.text.toString() + " " + channel
        if (channel == null)
        {
            builtStringForHeightDesc = usr_height_desc.text.toString() + " is not set!"
        }

        usr_height_desc.text = builtStringForHeightDesc
        calculate_button.setOnClickListener {
            if (channel != null)
            {
                val value = editTextNumber.text.toString()
                storeBMI(view.context, value)
                val intent = Intent( this.context, BarGraph::class.java)
                startActivity(intent)
            }
            else
            {
                Snackbar.make(view, getString(R.string.heightneeded_error),  BaseTransientBottomBar.LENGTH_SHORT).show()
            }

        }
    }
}