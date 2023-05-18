using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class Roots{
	public static vector NMBL(Func<vector,vector> f, vector x, double eps=1e-2){
		int dim=x.size;
		vector delX,x1;
		x1=x.copy();
		double val,lambda;
		matrix jacobi,Q,R;
		f(x1).print("f(x)= ");
		x1.print("x1= ");
		do{
			jacobi=jacobian(f,x1);
			(Q,R)=QRGS.decomp(jacobi);
			delX=QRGS.solve(Q,R,-f(x1));
			lambda=1;
			while(f(x1+lambda*delX).norm()>(1-lambda/2)*f(x1).norm() || lambda>Pow(2,-15)){
				lambda/=2;
			}
			x1 += lambda*delX;
			val = f(x1).norm();
		}while(val>eps);
		return x1;
	}
	public static matrix jacobian(Func<vector,vector> f, vector x){
		int dim=x.size;
		double dx;
		matrix jacobi= new matrix(dim,dim);
		vector xj = new vector(dim);
		for(int i=0;i<dim;i++){
			for(int j=0;j<dim;j++){
				dx=Abs(x[i])*Pow(2,-26);
				xj=x.copy();
				xj[j]+=dx;
				jacobi[i,j]=(f(xj)[i]-f(x)[i])/dx;
			}
		}
		return jacobi;
	}
}
