using static System.Console;

class main{
	static void Main(){
		for(double x=1.0/128;x<=16;x+=1.0/64){
			WriteLine($"{x} {sfuns.lngamma(x)}");
		}
	}
}
