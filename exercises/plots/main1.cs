using static System.Console;
class main1{
	static void Main(){
		for(double i=1.0/64;i<3.5;i+=1.0/64)
			WriteLine($"{i} {sfuns.erf(i)}");
	}
}
