using static System.Math;
using static System.Console;

static class math{
	static void Main(){
		double sqrt2=Sqrt(2.0);
		double ePi=Exp(PI);
		double piE=Pow(PI,E);
		Write($"The values are \n");
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"exp(pi) = {ePi}\n");
		Write($"pi^e = {piE}\n");
		
		Write($"Checking values \n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be 2) \n");
		Write($"exp(pi)^(1/pi) = {Pow(ePi,1/PI)}\n");
		Write($"(pi^e)^(1/e) = {Pow(piE,1/E)}\n");
	}
}
