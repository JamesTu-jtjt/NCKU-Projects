#Ex4
barplot(VADeaths, beside=TRUE, legend=TRUE, ylim=c(0,90), ylab="Deaths per 1000", main="Death rates in Virginia")

barplot(VADeaths, beside=F, legend=F, ylim=c(0,90), ylab="Deaths per 1000", main="Death rates in Virginia")

barplot(VADeaths, beside=F, legend=TRUE, ylim=c(0,90), ylab="Deaths per 1000", main="Death rates in Virginia")

dotchart(VADeaths,xlim=c(0,90), xlab="Deaths per 1000", main="Death rates in Virginia")

VADeaths
class(VADeaths)
#[1] "matrix"

groupsizes<-c(18,30,32,10,10)
labels<-c("A","B","C","D","F")
pie(groupsizes, labels, col=c("green", "blue","red","black", "grey90"))


x<-rgamma(100, shape=1)
hist(x)

log2(100)
?hist

hist(x,breaks=7)
hist(x,breaks=3)
hist(x,breaks=100)

1000^(1/3)
hist(x, breaks=5)
hist(x, breaks="Scott")
hist(x, breaks="Freedman-Diaconis")

boxplot(Sepal.Length~Species,data=iris,ylab="Sepal length(cm)", main="Iris measurements",boxwex=o.5)

x<-rnorm(100) #assigns 100 random normal observations to x
y<-rpois(100,30)
plot(x,y,main="Poisson vs Normal")

plot(x,y,type="l")
plot(sort(x),sort(y),type="l")

old.par=par()
par(mfrow=c(1,2))
hist(x,breaks=10,main="Norm")
hist(y,breaks=10,main="Pois")

plot(x,y)
plot(x,y)

par(old.par)
plot(x,y)

X<-rnorm(1000)
A<-rnorm(1000)
qqplot(X,A,main="A and x are the same")
B<-rnorm(1000,mean=3,sd=2)
qqplot(X,B,main= "B is rescaled X")
C<-rt(1000,df=2)
qqplot(X,C,main="C has heavier tails")
D<-exp(rnorm(1000))
qqplot(X,D,main="D is skewed to the right")

qqnorm(X)

pairs(stackloss)

source("finger.txt")
indexfinger=read.table("finger.txt", header=T)

plot(width~length, data=indexfinger)
with(indexfinger[c(3, 7),], points(length, width, pch=16))

plot(width~length, pch=as.character(sex), data=indexfinger)

par(mar=c(5, 5, 5, 5) + 0.1)
plot(c(1, 9), c(0, 50), type="n", xlab="", ylab="")
text(6, 40, "Plot region")
points(6, 20)
text(6, 20, "(6, 20)", adj=c(0.5, 2))
mtext(paste("Margin", 1:4), side=1:4, line=3)
mtext(paste("Line", 0:4), side=1, line=0:4, at=3, cex=2)
mtext(paste("Line", 0:4), side=2, line=0:4, at=15, cex=0.01)
mtext(paste("Line", 0:4), side=3, line=0:4, at=3, cex=0.6)
mtext(paste("Line", 0:4), side=4, line=0:4, at=15, cex=0.6)


#Exercises
#Exercise3.1.6
#3a
plot(pressure, xlab="temperature", main="pressure")
#non-linear

#3b
residuals1<-with(pressure,pressure-(0.168+0.007*temperature)^(20/3))
qqplot(rnorm(19),residuals1)
#skewed distribution

#3c 
power.transformation<-with(pressure, pressure^(3/20))
plot(power.transformation, xlab="temperature", ylab="pressure", main="pressure")
#evidently linear

#3d
residuals2<-with(pressure, pressure^(3/20)-(0.168 + 0.007*temperature))
qqplot(rnorm(19),residuals2)
#skewed distribution

#Chapter exercise
#2a
plot(pressure, xlab="temperature", main="pressure")
curve((0.168 + 0.007*x)^(20/3), from=0, to=400, add=TRUE)

#2b
power.transformation<-with(pressure, pressure^(3/20))
plot(power.transformation, xlab="temperature", ylab="pressure", main="pressure")
abline(0.168,0.007)

#2c
power.transformation<-with(pressure, pressure^(3/20))
plot(power.transformation, xlab="temperature", ylab="pressure", main="Testing Linear Relationship with Power Function")
abline(0.168,0.007)

#2d
par(mfrow=c(2,1))
plot(pressure, xlab="temperature", main="pressure")
curve((0.168 + 0.007*x)^(20/3), from=0, to=400, add=TRUE)
power.transformation<-with(pressure, pressure^(3/20))
plot(power.transformation, xlab="temperature", ylab="pressure", main="pressure")
abline(0.168,0.007)

par(mfrow=c(1,2))
plot(pressure, xlab="temperature", main="pressure")
curve((0.168 + 0.007*x)^(20/3), from=0, to=400, add=TRUE)
power.transformation<-with(pressure, pressure^(3/20))
plot(power.transformation, xlab="temperature", ylab="pressure", main="pressure")
abline(0.168,0.007)




#ANSWER
#Chapter 3.1.6 Exercise 3
#(a)
plot(pressure)
#nonlinear

#(b)
residuals <-with(pressure, pressure-(0.168+0.007*temperature)^(20/3))
X <- rnorm(19,0,1)
qqplot(X,residuals)
#follow a skewed distribution

#(c)
new.pressure=pressure
new.pressure$pressure<-pressure$pressure^(3/20)
plot(new.pressure)
#linear

#(d)
residuals <-with(new.pressure, pressure-(0.168+0.007*temperature))
X <- rnorm(19)
qqplot(X,residuals)
#follow a skewed distribution

#Chapter 3 Exercises 2
#(a)
plot(pressure)
curve((0.168 + 0.007*x)^(20/3), from=0, to=400, add=TRUE)

#(b)
new.pressure=pressure
new.pressure$pressure<-pressure$pressure^(3/20)
plot(new.pressure)
#linearly
abline(0.168, 0.007)

#(c)
title(main="Plot of Pressure and Temperature")

#(d)
par(mfrow=c(2,1))
plot(pressure)
curve((0.168 + 0.007*x)^(20/3), from=0, to=400, add=TRUE)
plot(new.pressure)

par(mfrow=c(1,2))
plot(pressure)
curve((0.168 + 0.007*x)^(20/3), from=0, to=400, add=TRUE)
plot(new.pressure)
abline(0.168, 0.007)