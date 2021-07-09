#20201014
Fib1 <- 1
Fib2 <- 1
Fibonacci <- c(Fib1, Fib2)
while (Fib2 < 300) {
  Fibonacci <- c(Fibonacci, Fib2)
  oldFib2 <- Fib2
  Fib2 <- Fib1 + Fib2
  Fib1 <- oldFib2
}
Fibonacci


x <- 1
f <- x^3 + 2 * x^2 - 7
tolerance <- 0.000001
while (abs(f) > tolerance){ 
  f.prime <- 3 * x^2 + 4 * x
  x <- x - f / f.prime
  f <- x^3 + 2 * x^2 - 7
  }
x


x <- -1.5
f <- cos(x)+exp(x)
tolerance <- 0.000001
while (abs(f) > tolerance){ 
  f.prime <- -sin(x)+exp(x)
  x <- x - f / f.prime
  f <- cos(x)+exp(x)
}
x

x <- -1.5
f <- cos(x)+exp(x)+0.1
tolerance <- 0.000001
repeat{ 
  if (abs(f) < tolerance)break
  f.prime <- -sin(x)+exp(x)
  x <- x - f / f.prime
  f <- cos(x)+exp(x)+0.1
}
x


annuityAmt <- function(n, R, i) {
  R*((1 + i)^n - 1) / i
}

annuityAmt(10,400,0.05)

annuityAmt(n=10,i=0.05)

f <- function() {
  x <- 1
  g()
  return(x)
  }
g <- function() {
  x <- 2
  }
f()

f2 <- function() {
  x <- 1
  g2()
  return(x)
}
g2 <- function() {
  x <- 2
  y <- 2
  z <- 2*y
  print("z=", z)
}
f2()
g2()

sort <- function(x) {
  for(last in length(x):2){
    for(first in 1:(last-1)) {
      if(x[first] > x[first + 1]) { 
        save <- x[first]
        x[first] <- x[first + 1]
        x[first + 1] <- save
      }
    }
  }
  return (x)
}
data<-c(2, 24, 3, 4, 5, 13, 6, 1)
sort2 <- function(x) {
  for(last in length(x):2){
    for(first in 1:(last-1)) {
      if(x[first] > x[first + 1]) { 
        save <- x[first]
        x[first] <- x[first + 1]
        x[first + 1] <- save
      }
    }
  }
  return (x)
}
 sort2(data)
 
system.time(sort2(data))
system.time(sort2(sample(1:10000)))

system.time({x1=sort2(sample(1:10000))})
system.time({x2=sort2(sample(1:10000))})


mergesort <- function (x) {
  len <- length(x)
  if (len < 2) result <- x
  else {
    y <- x[1:(len %/% 2)]
    z <- x[(len%/%2+ 1):len]
    y <- mergesort(y)
    z <- mergesort(z)
    result <- c()
    while (min(length(y), length(z)) > 0) {
        if (y[1] < z[1]) {
          result <- c(result, y[1])
          y <- y[-1]
          } else {
            result <- c(result, z[1])
            z <- z[-1]
            }
      }
      if (length(y) > 0)
        result <- c(result, y)
    else
      result <- c(result, z)
    }
  return(result)
  }
mergesort(c(10:1))



#Exercise
#4.1.4 exercise7
i <- 0.006
a=0
f <- (1 - (1 + i)^(-20)) / 19-i
tolerance=0.000001
while (abs(f) > tolerance){ 
  f.prime <- 20/(19*(1+i)^21)-1
  i <- i - f / f.prime
  f <- (1 - (1 + i)^(-20)) / 19-i
  a=a+1
}
i
#[1] 0.004939979
a 
#[1] 2 iterations


#4.4.1 Exercise2
#a
dxy=function(f,g){
  x=1
  y=1
  fdx=D(f,"x")
  fdy=D(f,"y")
  gdx=D(g,"x")
  gdy=D(g,"y")
  tolerance=0.000001
  while (abs(eval(f))>tolerance||abs(eval(g))>tolerance){
    d=eval(fdx)*eval(gdy)-eval(fdy)*eval(gdx)
    x=x-(eval(gdy)*eval(f)-eval(fdy)*eval(g))/d
    y=y-(eval(fdx)*eval(g)-eval(gdx)*eval(f))/d
    typeof(abs(eval(f)))
    typeof(tolerance)
  }
  return(c(x,y))
}

#b
dxy(f=expression(x+y),g=expression(x^2+2*y^2-2))
#[1] -0.8164966  0.8164966


#Chapter Exercises
#1
directpoly<-function(x,c){
  len<-length(c)
  n2=0
  for (i in len:1){
    n1=c[i]*x^(i-1)
    n2=n1+n2
  }
  return(n2)
}

#2
hornerpoly<-function(x,c){
  len=length(c)
  a=c[len]
  for(j in (len-1):1){
    a=a*x+c[j]
  }
  return(a)
}

#3
#a
system.time(directpoly(x=seq(-10, 10, length=5000000),
                       c(1, -2, 2, 3, 4, 6, 7)))
#user  system elapsed 
#1.17    0.03    1.20 
system.time(hornerpoly(x=seq(-10, 10, length=5000000),
                       c(1, -2, 2, 3, 4, 6, 7)))
#user  system elapsed 
#0.11    0.00    0.11 

#b
system.time(directpoly(x=seq(-10, 10, length=5000000),c(2,17,-3)))
#user  system elapsed 
#0.31    0.01    0.33 
system.time(hornerpoly(x=seq(-10, 10, length=5000000),c(2,17,-3)))
#user  system elapsed 
#0.05    0.02    0.07 



#ANSWER
#4.1.4 exercise 7
i = 0.006
f = (1-(i+1)^(-20))/19 -i
tolerance = 0.000001
iteration = 0
repeat{
  if(abs(f) < tolerance) break
  iteration = iteration + 1
  f.prime = (20*(i+1)^(-21))/19-1
  i = i-f/f.prime
  f = (1-(i+1)^(-20))/19-i
}
i
print(paste("iteration times:",iteration))

#4.4.1 exercise 2
#(a)
# Step 1: Write the code to work for specific equations
x <- 1
y <- -1
f <- x + y
g <- x^2 + 2*(y^2) - 2
while ((abs(f)+abs(g)) >= 0.000001){
  f_x_n1 = 1 
  f_y_n1 = 1 
  g_x_n1 = 2*x 
  g_y_n1 = 4*y 
  f_n1 = x + y
  g_n1 = x^2 + 2*(y^2) - 2
  d_n1 = f_x_n1*g_y_n1 - f_y_n1*g_x_n1
  x = x - (g_y_n1*f_n1 - f_y_n1*g_n1)/d_n1
  y = y - (f_x_n1*g_n1 - g_x_n1*f_n1)/d_n1
  f = x + y
  g = x^2 + 2*(y^2) - 2
}
x#0.8164966
y#-0.8164966


# Step 2: Write a function to work for general equations
interation.f=function(x,y,fxy,gxy){
  f=eval(fxy)
  g=eval(gxy)
  while ((abs(f)+abs(g)) >= 0.000001){
    f_x_n1 = eval(D(fxy, 'x')) 
    f_y_n1 = eval(D(fxy, 'y')) 
    g_x_n1 = eval(D(gxy, 'x')) 
    g_y_n1 = eval(D(gxy, 'y')) 
    f_n1 = eval(fxy)
    g_n1 = eval(gxy)
    d_n1 = f_x_n1*g_y_n1 - f_y_n1*g_x_n1
    x = x-(g_y_n1*f_n1 - f_y_n1*g_n1)/d_n1
    y = y-(f_x_n1*g_n1 - g_x_n1*f_n1)/d_n1
    f = eval(fxy)
    g = eval(gxy)
  }
  return(c(paste("x:",x),paste("y:",y)))
}

interation.f(x=1,y=-1,fxy = expression(x+y),
             gxy = expression(x^2+2*(y^2)-2))
#[1] "x: 0.816496598639456"  "y: -0.816496598639456" # solution 1

interation.f(x=-1,y=1,fxy = expression(x+y),
             gxy = expression(x^2+2*(y^2)-2))
#[1] "x: -0.816496598639456" "y: 0.816496598639456"  #solution 2

# Step 3: Write a shorter function to work for general equations
iteration.f2 = function(x0,y0,f,g){
  x = x0
  y = y0
  newf = eval(f)
  newg = eval(g)
  tolerance = 0.000001
  repeat{
    if(abs(newf) < tolerance & abs(newg) < tolerance) break
    x = x - (eval(D(g,"y"))*eval(f)-eval(D(f,"y"))*eval(g))/(eval(D(f,"x"))*eval(D(g,"y"))-eval(D(f,"y"))*eval(D(g,"x")))
    y = y - (eval(D(f,"x"))*eval(g)-eval(D(g,"x"))*eval(f))/(eval(D(f,"x"))*eval(D(g,"y"))-eval(D(f,"y"))*eval(D(g,"x")))
    newf = eval(f)
    newg = eval(g)
  }
  return(c(paste("x:",x),paste("y:",y)))
}
#(b)
iteration.f2(0.05,0.05,expression(x+y),expression(x^2+2*y^2-2))
#[1] "x: -0.816496580927986" "y: 0.816496580927746"  # Solution 1

iteration.f2(1,-1,expression(x+y),expression(x^2+2*y^2-2))
#[1] "x: 0.816496584939634"  "y: -0.816496582281632" # Solution 2



#Chapter Exercise
#1.
directpoly = function(x,coefs){
  n = length(coefs)
  polys = c()
  for(x_num in 1:length(x)){
    monomers = c()
    for(i in 0:(n-1)){
      monomers[i+1] = coefs[i+1]*(x[x_num]^i)
    }
    polys[x_num] = sum(monomers)
  }
  return(polys)
}
directpoly(2,c(5,6,7))

#2.
hornerpoly = function(x,coefs){
  polys = c()
  for(x_num in 1:length(x)){
    n = length(coefs) 
    a = c()
    a[n] = coefs[n]
    for(i in (n-1):1){
      a[i] = a[i+1]*x[x_num]+coefs[i]
    }
    polys[x_num] = a[1]
  }
  return(polys)
}
hornerpoly(c(2,3),c(5,6,7))


#3.
#(a)
system.time(directpoly(seq(-10,10,length = 5000000),c(1,-2,2,3,4,6,7)))
system.time(hornerpoly(seq(-10,10,length = 5000000),c(1,-2,2,3,4,6,7)))

#(b)
system.time(directpoly(seq(-10,10,length = 5000000),c(-3,17,2)))
system.time(hornerpoly(seq(-10,10,length = 5000000),c(-3,17,2)))

#When the number of polynomial coefficients is smaller,
#there is less difference between directpoly and hornerpoly.
