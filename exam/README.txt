My exam project was to implement the Berrut B1 rational (24). This is been done and two plots of this
can be seen in "berrutSpline.svg" where the functions is calculated from 10 data points from
f(x)=x and g(x)=x^2. Then I tried som different methods to make the interplelation better by 
changing the span of the data and the amount of data points. This would make it possible to
collect data such the x values fits well to the Berrut splines. These trials can be seen in 
"berrutSplines.svg" where it has been tried to extend the span of the data, number of points
 and both. It can be seen from this that the greater span stop funky ocsilation but without 
 more data points you lose information like the amplitude getting smaller. So then I tried 
 seeing where this method helped the berrutsplines to convergence to the original functions.
 This can be seen in the figure "Convergence.svg". This shows that for functions that look like
 itself, such as a gaussian or Cos(x), it works well but it gets worse for data with increasing
 value like x^2. Lastly i parallelized the sum of the numinator and denominator to speed up the proces.
 This result can been seen in "Out.txt" where it varies a bit if the more threads helps 
 depending of the size of the data sets, but with very large sets the threading is faster and
 this shows the the program is parallelized but sometimes the joining of the threads and
 fetching of all the data makes it slower and this varies from run to run, but most of the time
 more threads is faster on large sets. I would think this makes this projekt worth 10 points
