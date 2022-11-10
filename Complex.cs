using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnerKomplex
{
    class Complex
    {
        private double a, b; //des Standardtyps "double", auf die von "außen" kein Zugriff möglich ist
        public Complex() //Wird kein Parameter angegeben, so sind Real- und Imaginärteil mit 0 vorzubelegen.
        {
            a = 0;
            b = 0;
        }

        public Complex(double a_, double b_) //eine Initialisierung mit 2 "double"-Parametern soll möglich sein. a als Realteil und b als Imaginärteil.
        {
            a = a_;
            b = b_;
        }
        public Complex(double a_) // Bei Angabe nur eines Parameters erhält der Realteil diesen Wert, der Imaginärteil erhält den Wert 0
        {
            a = a_;
            b = 0;
        }

        public Complex Calc(Complex comp, char op) //add, sub, mul und div
        {
            Complex returncomplex = new Complex();
            double newa;
            double newb;

            if (op == '+')
            {
                newa = comp.a + a;
                newb = comp.b + b;
                returncomplex.a = newa;
                returncomplex.b = newb;
            }
            else if (op == '-')
            {
                newa = a - comp.a;
                newb = b - comp.b;
                returncomplex.a = newa;
                returncomplex.b = newb;
            }
            else if (op == '*')
            {
                newa = a * comp.a - b * comp.b;
                newb = a * comp.a + b * comp.b;
                returncomplex.a = newa;
                returncomplex.b = newb;
            }
            else if (op == '/')
            {
                newa = (a * comp.a + b * comp.b) / (Math.Pow(comp.a, 2) + Math.Pow(comp.b, 2));
                newb = (b * comp.a - a * comp.b) / (Math.Pow(comp.a, 2) + Math.Pow(comp.b, 2));
                returncomplex.a = newa;
                returncomplex.b = newb;
            }

            return returncomplex;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex returncomplex = new Complex();
            returncomplex.a = c1.a + c2.a;
            returncomplex.b = c1.b + c2.b;
            return returncomplex;
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex returncomplex = new Complex();
            returncomplex.a = c1.a - c2.a;
            returncomplex.b = c1.b - c2.b;
            return returncomplex;
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex returncomplex = new Complex();
            returncomplex.a = c1.a * c2.a - c1.b * c2.b;
            returncomplex.b = c1.a * c2.a + c1.b * c2.b;
            return returncomplex;
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex returncomplex = new Complex();
            returncomplex.a = (c1.a * c2.a + c1.b * c2.b) / (Math.Pow(c2.a, 2) + Math.Pow(c2.b, 2));
            returncomplex.b = (c1.b * c2.a - c1.a * c2.b) / (Math.Pow(c2.a, 2) + Math.Pow(c2.b, 2));
            return returncomplex;
        }


        public override string ToString() //eine Komplexe Zahl in der Form „? + j·?“ auszugeben.
        {
            return a + " + j · " + b;
        }

        //Zur Ausgabe von a und b verwende ich GetA() und GetB(). 
        public double GetA()
        {
            return a;
        }

        public double GetB()
        {
            return b;
        }
    }
}
