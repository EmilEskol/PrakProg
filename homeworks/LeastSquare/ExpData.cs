using static System.Console;
using static matrix;

class Expdata{
	static void Main(){
		vector x=new vector("1,2,3,4,6,9,10,  13,  15");
		vector y=new vector("117,100,88,72,53,29.5,25.2,15.2,11.1");
		vector dy= new vector("5,5,5,4,4,3,3,2,2");
		for(int i=0;i<x.size;i++)
			WriteLine($"{x[i]} {y[i]} {dy[i]}");
	}
}
