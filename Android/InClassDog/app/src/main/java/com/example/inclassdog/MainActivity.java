package com.example.inclassdog;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import org.w3c.dom.Text;

public class MainActivity extends AppCompatActivity {

    Dog fido;
    Dog milo;

    public MainActivity()
    {
        milo = new Dog();
        milo.Name = "Milo!";
        milo.Age = 7;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main); //res folder

        fido = new Dog();

        Button btn = (Button)this.findViewById(R.id.buttonPressMe);
        TextView tv2 = (TextView) this.findViewById(R.id.textView2);
        TextView tvW = (TextView) this.findViewById(R.id.textViewWeight);


        btn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                tv2.setText(fido.About() + " \n" + milo.About());
            }
        });
    }

    public void buttonEat_OnCLick(View v)
    {
        milo.Eat();
    }
}