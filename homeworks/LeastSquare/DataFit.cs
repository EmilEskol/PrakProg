using static System.Console;
using static System.Math;

class main{
	static void Main(){
		double b=4.95,a=-0.17;
		for(double x=0;x<15;x+=0.1)
			WriteLine($"{x} {Exp(b+a*x)}");
	}
}
