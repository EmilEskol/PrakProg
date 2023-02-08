using static System.Math;
using static System.Console;

static class math{
	static void Main(){
		double sqrt2=Sqrt(2.0);
		double twoToAFifth=Pow(2,0.2);
		double ePi=Exp(PI);
		double piE=Pow(PI,E);
		Write($"The values are \n");
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"2^1/5 = {twoToAFifth}\n");
		Write($"exp(pi) = {ePi}\n");
		Write($"pi^e = {piE}\n");
		
		Write($"\nChecking values \n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be 2) \n");
		Write($"2^1/5^5 = {Pow(twoToAFifth,5)} (should be 2) \n");
		Write($"exp(pi)^(1/pi) = {Pow(ePi,1/PI)} (should be e) \n");
		Write($"(pi^e)^(1/e) = {Pow(piE,1/E)} (should be pi) \n");

		Write($"\n2. Gammafunction \n");
		Write($"gammaFunc(1) = {sfuns.gamma(1)}\n");
		Write($"gammaFunc(2) = {sfuns.gamma(2)}\n");
		Write($"gammaFunc(3) = {sfuns.gamma(3)}\n");
		Write($"gammaFunc(10) = {sfuns.gamma(10)}\n");

		Write($"\n3. LnGammafunction \n");
		Write($"lngammaFunc(1) = {sfuns.lnGamma(1)}\n");
		Write($"lngammaFunc(2) = {sfuns.lnGamma(2)}\n");
		Write($"lngammaFunc(3) = {sfuns.lnGamma(3)}\n");
		Write($"lngammaFunc(10) = {sfuns.lnGamma(10)}\n");

	}
}
