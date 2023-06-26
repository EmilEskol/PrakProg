using System;
using static System.Console;
using static System.Math;
public class BerrutSpline{
	vector x,y;
	double numer,denom;//numerater and denominator
	int n;
	public BerrutSpline(vector xs,vector ys){
		n=xs.size;
		x=xs.copy();
		y=ys.copy();
	}
	public double evaluate(double z){
		numer=0;
		denom=0;
		//WriteLine($"z={z}");
		for(int i=0;i<n;i++){
			if(z==x[i])
				return y[i];
			numer+=Pow(-1,i)/(z-x[i])*y[i];
			denom+=Pow(-1,i)/(z-x[i]);
			//WriteLine($"i={i},numerator={numer}, demoninator={denom}");
		}
		//WriteLine($"val={numer/denom}");
		return numer/denom;
	}
	public (double[],double[]) printData(int m){
			int size=(n-1)*m;
			double step;
			double[] xData = new double[size];
			double[] yData = new double[size];
			for(int i=0;i<n-1;i++){
				for(int j=0;j<m;j++){
					step=(j-1)*(x[i+1]-x[i])/m;
					xData[m*i+j]=x[i]+step;
					yData[m*i+j]=evaluate(xData[m*i+j]);
				}
			}
		return (xData,yData);
	}
	/*public double derivative(double z){
		int i=Spline.binSearch(x,z);
		return b[i]+2*c[i]*(z-x[i]);
	}*/
	/*public double integral(double z){
		int i=Spline.binSearch(x,z);
		if(i==0)
			return  y[i]*(z-x[i])+0.5*b[i]*Pow(z-x[i],2)+1/3*c[i]*Pow(z-x[i],3);
		double k=integral(x[i]-0.00000001);
		return  k+y[i]*(z-x[i])+0.5*b[i]*Pow(z-x[i],2)+1/3*c[i]*Pow(z-x[i],3);
	}*/
	/*public (double[],double[]) printDerivative(int m){
			int size=(n-1)*m;
			double step;
			double[] xData = new double[size];
			double[] yData = new double[size];
			for(int i=0;i<n-1;i++){
				for(int j=0;j<m;j++){
					step=j*(x[i+1]-x[i])/m;
					xData[m*i+j]=x[i]+step;
					yData[m*i+j]=b[i]+2*c[i]*(step-x[i]);
				}
			}
		return (xData,yData);
	}*/
	/*public (double[],double[]) printIntegral(int m){
			int size=(n-1)*m;
			double step;
			double[] xData = new double[size];
			double[] yData = new double[size];
			for(int i=0;i<n-1;i++){
				for(int j=0;j<m;j++){
					step=j*(x[i+1]-x[i])/m;
					xData[m*i+j]=x[i]+step;
					yData[m*i+j]=integral(x[i]+step);
				}
			}
		return (xData,yData);
	}*/
}
