using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Minimi;

public class main{
	static double acc;
	static vector start,result;
	static genlist<double> energy = new genlist<double>();
	static genlist<double> signal = new genlist<double>();
	static genlist<double> error  = new genlist<double>();
	static Func<vector,double> f;
		
	public static void Main(string[] args){
		WriteLine("=========Part a============");
		WriteLine("Finding minimum of x^2 + y^2");
		f = x => x[0]*x[0]+x[1]*x[1];
		var rnd = new Random();
		acc=0.01;
		start = new vector(rnd.NextDouble()*10-5,rnd.NextDouble()*10-5);
		start.print("Start guess is at ");
		result=qnewton(f,start,acc);
		result.print("The minimum of x^2+y^2 is at ");
		
		WriteLine("\n finding minimum of the Rosenbrocks valley function");
		f= x=>Pow(1-x[0],2)+100*Pow(x[1]-x[0]*x[0],2);
		start = new vector(rnd.NextDouble()*4-2,rnd.NextDouble()*4-1);
		start.print("Start guess is at ");
		result=qnewton(f,start,acc);
		result.print("A minimum of Rosenbrocks valley function is at ");
		WriteLine($"and the value is {f(result)}");

		WriteLine("\n finding minimum of the HimmelBlau's function ");
		f=x=>Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7,2);
		start = new vector(rnd.NextDouble()*6-3,rnd.NextDouble()*6-3);
		start.print("Start guess is at ");
		result=qnewton(f,start,acc);
		result.print("A minimum of HimmelBlau's function is at ");
		WriteLine($"and the value is {f(result)}");

		WriteLine("=========Part b=============");
		WriteLine("Finding the mass and the experimetnal width of the Higgs boson");
		var options = StringSplitOptions.RemoveEmptyEntries;
		var separators = new char[] {' ','\t'};
		do{
		        string line=Console.In.ReadLine();
		        if(line==null)break;
		        string[] words=line.Split(separators,options);
		        energy.add(double.Parse(words[0]));
		        signal.add(double.Parse(words[1]));
		        error .add(double.Parse(words[2]));
		}while(true);
		IOputs.WriteXY(args,energy,signal,error,"MeasHiggs.data");
		//Start guass scale factor (A)=1,mass (a)=0.1,width (gamma)=0.1
		start=new vector(1,120,5);
		acc=0.01;
		result=qnewton(f,start,acc);
		WriteLine($"The value at the minimum is {diff(result)}");
		WriteLine($"the found mass is {result[1]} and the width is {result[2]}");
		vector x1=new vector(4);
		double[] val=new double[200];
		double[] ener=new double[200];
		for(int j=1;j<4;j++){
				x1[j]=result[j-1];
			}
		for(int i=0;i>200;i++){
			ener[i]=100+6.0/20*i;
			x1[0]=ener[i];
			val[i]=f(x1);
		}
		IOputs.WriteXY(args,ener,val,"FitHiggs.data");
		
	}
	public static double diff(vector guess){
		double sum=0;
		vector x1= new vector(4);
		//Vector for function (E,A,m,gamma) which is (Enerngy,scale factor, mass, width)
		f= x=> x[1]/(Pow(x[0]-x[2],2)+x[3]*x[3]/4);

		for(int i=0;i<energy.size;i++){
			x1[0]=energy[i];
			for(int j=1;j<4;j++){
				x1[j]=guess[j-1];
			}
			sum+=Pow(f(x1)-signal[i]/error[i],2);
		}
		return sum;
	}
}
