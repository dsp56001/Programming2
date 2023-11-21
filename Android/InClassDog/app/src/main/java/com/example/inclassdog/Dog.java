package com.example.inclassdog;

public class Dog {
    public String Name; //string class is capital
    public int Age;
    public int Weight;

    public Dog() {
        this.Name = "fido";
        this.Age = 2;
        this.Weight = 3;
    }

    public void Eat()
    {
        this.Weight++;
    }

    public String About()
    {
        return String.format("Hello my name is %s and I'm %s years old I weight %s", this.Name, this.Age, this.Weight);
    }

}
