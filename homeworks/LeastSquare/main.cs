using System;
using static System.Math;
using static System.Console;
using static matrix;
using static LS;

static class main{
	static int Main(string[] args){
		//Data and function
		Func<double,double>[] fs=new Func<double,double>[] {z=>1,z=>-z};
		vector x=new vector("1,2,3,4,6,9,10,  13,  15");
		vector y=new vector("117,100,88,72,53,29.5,25.2,15.2,11.1");
		vector dy= new vector("5,5,5,4,4,3,3,2,2");
		vector Lny=new vector(y.size);
		vector dLny=new vector(y.size);
		for(int i=0;i<y.size;i++){
			Lny[i]=Log(y[i]);
			dLny[i]=dy[i]/y[i];
			}
		(vector c,matrix cov)= LSfit(fs,x,Lny,dLny);
		Write("The result of the ordinary LS fit is ");
		c.print("\nCoefficients :\n");
		cov.print("Covarriance matrix:\n");
		Write($"The half time is {Log(2)/c[1]} with an error of {Log(2)/(c[1]*c[1])*Sqrt(cov[1,1])}\n");
		WriteLine("The modern value of the half time of 224Ra is 3.6 days");
		WriteLine(", which doesn't agree with the data and error given ");
		double[] xs=new double[150];
		double[] ys=new double[150];
		double[] ysU=new double[150];
		double[] ysD=new double[150];
		double dc1=Sqrt(cov[1,1]);
		double dc0=Sqrt(cov[0,0]);
		for(int i=0;i<150;i++){
			xs[i]=i*0.1;
			ys[i]=Exp(c[0]-c[1]*(0.1*i));
			ysU[i]=Exp(c[0]+dc0-(c[1]-dc1)*(0.1*i));
			ysD[i]=Exp(c[0]-dc0-(c[1]+dc1)*(0.1*i));
		}
		IOputs.WriteXY(args,xs,ys,"DataFit.data");
		IOputs.WriteXY(args,xs,ysU,"DataFitU.data");
		IOputs.WriteXY(args,xs,ysD,"DataFitD.data");
		IOputs.WriteXY(args,x,y,dy,"ExpData.data");
		return 0;
	}
}
