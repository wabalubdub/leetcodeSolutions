namespace fractions{

    public class Solution {
    public string FractionAddition(string expression) {
       List<Fraction> fractions = parseExprestion(expression);
       Fraction returnfraction = new Fraction(0,1);
       foreach (Fraction fraction in fractions) 
       {
        returnfraction = returnfraction.Add(fraction);
       }
       return returnfraction.ToString();
    }
    public static List<Fraction> parseExprestion(string expression) {
        string newExpresion;
        newExpresion =expression.Replace("+","*+");
        newExpresion = newExpresion.Replace("-","*-");
        string[] tokens = newExpresion.Split("*");
        List<Fraction> fractions = new List<Fraction>();
        foreach (string token in tokens) 
        {
            fractions.Add(Fraction.FromString(token));
        }

        return fractions;
    }
    public static class Utils
    {
        public static int GCD(int a, int b) 
        {
            if (a == 0){return b;} 
            return GCD(b%a,a); 
        }
        public static int LCM(int a,int b){
            return (a*b)/GCD(a,b);
        }
    }
    public class Fraction{
        public int _numerator;
        public int _denominator;

        public Fraction ( int numerator,int denominator)
        {
            int simplify =Utils.GCD(Math.Abs(numerator), denominator);
            _numerator = numerator/simplify;
            _denominator = denominator/simplify;
        }
        public Fraction Add(Fraction fractionOther){
            Fraction returnFraction;
            int lcd = Utils.LCM(this._denominator,fractionOther._denominator);
            returnFraction = new Fraction(this._numerator*lcd/this._denominator+fractionOther._numerator*lcd/fractionOther._denominator,lcd);
            return returnFraction;
        }

        public static Fraction FromString (string str){
            if (str == ""){return new Fraction(0,1);}
            string[] parts = str.Split("/");
            int numarator=int.Parse(parts[0]);
            int denominator=int.Parse(parts[1]);
            return new Fraction(numarator, denominator);
        }
        public override string ToString(){
            return $"{_numerator}/{_denominator}";
        }
    }

}
}