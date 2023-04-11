using System;
using static System.Math;
using static System.Console;
using static matrix;
using static LS;

static class main{
	static int Main(){
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
		c.print("Ordinary LS fit:\n");
		cov.print("Covarriance matrix:\n");
		Write($"The half time is {Log(2)/c[1]} with an error of {Log(2)/(c[1]*c[1])*Sqrt(cov[1,1])}\n");
		WriteLine("The modern value of the half time of 224Ra is 3.6 days");
		WriteLine(", which doesn't agree with the data and error given ");
		return 0;
	}
}
