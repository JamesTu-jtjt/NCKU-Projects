#20201007
Fibo=numeric(12)
Fibo[1]=Fibo[2]=1
for (i in 3:12) Fibo[i] <- Fibo[i - 2] + Fibo[i - 1]
Fibo

Fibo=numeric(12)
Fibo

Fibo=numeric(12)
Fibo[1]=Fibo[2]=1
for (i in 3:13) Fibo[i] <- Fibo[i - 2] + Fibo[i - 1]
Fibo

Fibo=numeric(12)
Fibo[1]=Fibo[2]=1
for (i in 3:13) 
  {Fibo[i] <- Fibo[i - 2] + 
  Fibo[i - 1]
  print(Fibo[12])}
Fibo

i <- 0.006
for (j in 1:1000) {
  i <- (1 - (1 + i)^(-20)) / 19}
i

i <- 0.006
for (j in 1:1100) {
  i <- (1 - (1 + i)^(-20)) / 19}
i

index.v=seq(1,1000,by=2)

i <- 0.006
for (j in index.v) {
  i <- (1 - (1 + i)^(-20)) / 19}
i

index.v=seq(1,10,by=2)

for (j in index.v) {
  out=j^2
  print(out)}

index.v=c("a","b","c")

for (j in index.v) {
  out=paste(j,"-out",sep="")
  print(out)}

x <- 3
if (x > 2) y <- 2 * x else y <- 3 * x
y


coplot <- function(x, y, plotit) {
   if (plotit == TRUE) plot(x, y)
   cor(x, y)
   }

set.seed(10)
coplot(rnorm(100),rexp(100),plotit=F)
coplot(rnorm(100),rexp(100),plotit=T)

any(c(2,4,6)==6)

Eratosthenes <- function(n) {
     if (n >= 2) {
       sieve <- seq(2, n)
       primes <- c()
       for (i in seq(2, n)) {
         if (any(sieve == i)) {
           primes <- c(primes, i)
           sieve <- c(sieve[(sieve %% i) != 0], i)
           }
         }
       return(primes)
       } else {
         stop("Input value of n should be at least 2.")
         }
   }

Eratosthenes(1000)




#Exercise2
#a
Fibo=numeric(32)
Fibo[1]=Fibo[2]=1
for (i in 3:32) Fibo[i] <- Fibo[i - 2] + Fibo[i - 1]
Fibof=numeric(30)
for (j in 2:30) Fibof[j-1]=(Fibo[j])/(Fibo[j - 1])
Fibof
#converges

#b
gr=(1+sqrt(5))/2
gr
#yes
#Once the sequence Fibof reaches a point in its sequence, 
#all ratios of Fibof[n]=Fibo[n]/Fibo[n-1]=(1+sqrt(5))/2


#Exercise5
fpi<-function(sv){
  value=c()
  for(j in 1:100) {
    sv<-cos(sv)
    value=c(value,sv)
  }
  return(value)
}
fpi(0.5)
fpi(0.7)
fpi(0.0)
#starting value = 0.5; 2digits: 15; 3digits: 10; 4digits: 25
#starting value = 0.7; 2digits: 11; 3digits: 16; 4digits: 21
#starting value = 0.0; 2digits: 17; 3digits: 22; 4digits: 27


#Exercise6
fpi1<-function(sv1){
  value=c()
  for(j in 1:300) {
    sv1<-1.5*cos(sv1)
    value=c(value,sv1)
  }
  return(value)
}
#a 
fpi1(0.5)
#doesn't appear to converge
fpi2<-function(sv2){
  value=c()
  for(j in 1:300) {
    sv2<-cos(sv)/30+(44*sv2)/45
    value=c(value,sv2)
  }
  return(value)
}
#converges to 0.9148565
fpi2(0.5)
fpi2(0.7)
fpi2(0.0)

#b
#x=cos(x)/30+(44x)/45
#=> 45x=1.5cos(x)+44x
#=> x=1.5cos(x)
#They are equal
x = 0.9148565
curve(1.5*cos(x), from=0, to=2,xlim = c(0,2),ylim = c(-0.5,2),ylab="y=f(x)")
curve(1*x, from=-2, to=2, add=TRUE,col=rgb(1,0,0,1))
curve(cos(x)/30 + 44*x/45, from=-2, to=2, add=TRUE,col=4)
points(x,x,pch=19)
legend("bottomright",legend = c("y=1.5*cos(x)","y=x","y=cos(x)/30+44*x/45"),
       lty=c(1),col=c(1,rgb(1,0,0,1),4,1))
text(x,x+.5,labels=paste(x))
# the solutions to the two equations are the same

#c
fpi1d<-function(sv1d){
  value=c()
  for(j in 1:300) {
    sv1d<-1.5*sin(sv1d)
    value=c(value,sv1d)
  }
  return(value)
}
fpi2d<-function(sv2d){
  value=c()
  for(j in 1:300) {
    sv2d<-sin(sv2d)/30
    value=c(value,sv2d)
  }
  return(value)
}
fpi1d(0.9)
fpi2d(0.9) 
#fpi1>1 ; fpi2d<1
fpi2(0.5)
fpi2(0.7)
fpi2(0.0)
#True


#(c)
#d(1.5cos(x))/dx = -1.5sin(x)
#d(cos(x)/30 + 44x/45)/dx = -sin(x)/30+44/45

x=0.9 # close to the solution 0.9148565
-1.5*sin(x)
-sin(x)/30+44/45
#|-1.5sin(x)| > 1 , doesn't converge
#|-sin(x)/30+44/45| < 1 , converge


#Exercise3
Eratosthenes <- function(n) {
  if (n >= 2) {
    sieve <- seq(2, n)
    primes <- c()
    for (i in seq(2, n)) {
      if (any(sieve == i)) {
        primes <- c(primes, i)
        sieve <- c(sieve[(sieve %% i) != 0], i)
      }
    }
    return(primes)
  } else {
    stop("Input value of n should be at least 2.")
  }
}

a=c(Eratosthenes(1000))
pp<-c()
for (i in 1:168) {if ((a[i]+2) %in% a ) pp<-c(pp, c('(',a[i],',',a[i]+2,')'))}
noquote(pp)


#Exercise5
R=function(n,P,open) { 
  if (open==T) i=0.005
  else{i =0.004}
  (P*i)/(1-(1+i)^(-n))
}

#ANSWER
#Chapter 4.1.1
#2
#(a)
Fibo=numeric(30)
Fibo[1] = Fibo[2] = 1
for (i in 3:30) Fibo[i] = Fibo[i-2] + Fibo[i-1]
Fn_Fn_minus1 = numeric(30)
Fn_Fn_minus1[1]=1/0
for (i in 2:30) Fn_Fn_minus1[i] = Fibo[i] / Fibo[i-1]
Fn_Fn_minus1
#converging
#(b)
golden_ratio=(1+ 5^(1/2))/2
golden_ratio
#the sequence converging to this ratio

#5
iteration <- function(x, digits) {
  for (j in 1:1000){
    last_x=x
    x=cos(x)
    if (last_x%/%(0.1^digits) == x%/%(0.1^digits)){
      break()}
  }
  return(j)
}
iteration(0.5, 2)
#It takes 15 iterations for 2 digits
iteration(0.5, 3)
#It takes 20 iterations for 3 digits
iteration(0.5, 4)
#It takes 25 iterations for 4 digits

x=0.7
iteration(0.7, 2)
#It takes 11 iterations for 2 digits
iteration(0.7, 3)
#It takes 16 iterations for 3 digits
iteration(0.7, 4)
#It takes 21 iterations for 4 digits

x=0.0
iteration(0.0, 2)
#It takes 17 iterations for 2 digits
iteration(0.0, 3)
#It takes 22 iterations for 3 digits
iteration(0.0, 4)
#It takes 27 iterations for 4 digits

#6
#(a)
x=0.5
for (j in 1:1000){
  x=1.5*cos(x)}
x
x=0.5
for (j in 1:1001){
  x=1.5*cos(x)}
x
#x = 0.1230755 or 1.488654, doesn't converge
x=0.5
for (j in 1:1001){
  x = cos(x)/30 + 44*x/45}
x
x = 0.9148565
#x = 0.9148565 , converge

#(b)
x = 0.9148565
curve(1.5*cos(x), from=0, to=2,xlim = c(0,2),ylim = c(-0.5,2),ylab="y=f(x)")
curve(1*x, from=-2, to=2, add=TRUE,col=rgb(1,0,0,1))
curve(cos(x)/30 + 44*x/45, from=-2, to=2, add=TRUE,col=4)
points(x,x,pch=19)
legend("bottomright",legend = c("y=1.5*cos(x)","y=x","y=cos(x)/30+44*x/45"),
       lty=c(1),col=c(1,rgb(1,0,0,1),4,1))
text(x,x+.5,labels=paste(x))
# the solutions to the two equations are the same

#(c)
#d(1.5cos(x))/dx = -1.5sin(x)
#d(cos(x)/30 + 44x/45)/dx = -sin(x)/30+44/45

x=0.9 # close to the solution 0.9148565
-1.5*sin(x)
-sin(x)/30+44/45
#|-1.5sin(x)| > 1 , doesn't converge
#|-sin(x)/30+44/45| < 1 , converge

#Chapter 4.1.2
#3
Eratosthenes <- function(n) {
  if (n >= 2) {
    sieve <- seq(2, n)
    primes <- c()
    for (i in seq(2, n)) {
      if (any(sieve == i)) {
        primes <- c(primes, i)
        sieve <- c(sieve[(sieve %% i) != 0],i)
      }
    }
    return(primes)
  } else {
    stop("Input value of n should be at least 2.")
  }
}
primes = Eratosthenes(1000)
pair_primes = c()
j=1
for (i in primes) {
  if (any(primes == i+2)) {
    pair_primes[[j]] <- c(i,i+2)
    j=j+1
  }
}
pair_primes

#5
monthly_mortgage_payment <- function(n,P,open) {
  if (open){i = 0.005}
  else {i = 0.004}
  R = P*i/(1 - (1 + i)^(-n))
  return(R)
}
