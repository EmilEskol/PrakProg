using System;
using static System.Console;
using static System.Math;
using static matrix;
using static Minimi;

class main{
	static double acc;
	static vector start,result;
	static Func<vector,double> f;
	static double[] xMes,yMes;

	static void Main(string[] args){
		WriteLine("Fitting time data on a*x^3+b using minimiser, which results in ");
		(xMes,yMes) =IOputs.ReadXY(args);
		acc=0.01;
		start=new vector("1,0");
		
		
		double[] xFit= new double[200];
		double[] yFit= new double[200];
		f= x=> x[2]+(1e-8)*x[1]*Pow(x[0],3);

		
		result=qnewton(diff,start,acc);
		vector x1= new vector(3);
		for(int j=1;j<3;j++){
				x1[j]=result[j-1];
			}
		for(int i=0;i<200;i++){
			xFit[i]=1600.0/200*i;
			x1[0]=xFit[i];
			yFit[i]=f(x1);
		}
		IOputs.WriteXY(args,xFit,yFit,"partCfit.data");
		result[0]=result[0]*(1e-8);
		result.print("Fitting parameters (a,b) of a*x^3+b ");

	}
	public static double diff(vector guess){
		double sum=0;
		vector x1= new vector(3);
		//Vector for function (N,a,b)
		f= x=> x[2]+(1e-8)*x[1]*Pow(x[0],3);

		for(int i=0;i<xMes.Length;i++){
			x1[0]=xMes[i];
			for(int j=1;j<3;j++){
				x1[j]=guess[j-1];
			}
			//WriteLine($"{i} f(x)={f(x1)} yMes= {yMes[i]}");
			sum+=Pow(f(x1)-yMes[i],2);
		}
		return sum;
	}
}
