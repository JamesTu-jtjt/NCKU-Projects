#2020/10/21
set.seed(10)
X <- rnorm(100000)
Y<- rnorm(100000)
Z <- c()

system.time(for(i in 1:100000){Z<-c(Z,X[i]+Y[i])})
#user  system elapsed 
#25.08    0.12   25.20 

Z[1:10]
Z <- rep(NA, 100000)
system.time(for (i in 1:100000) {Z[i] <- X[i] + Y[i]})
#user  system elapsed 
#0.02    0.00    0.02 


system.time(Z <- X + Y)
#user  system elapsed 
#0       0       0 


set.seed(10)
n=10^8
X <- rnorm(n)
Y <- rnorm(n)
Z <- rep(NA, n)
system.time(for (i in 1:n) {Z[i] <- X[i] + Y[i]})
#user  system elapsed 
#6.00    0.02    6.02 
system.time(Z <- X + Y)
#user  system elapsed 
#0.18    0.00    0.19 

random.number<-numeric(50)
random.seed <- 27218
for (j in 1:50) {
  random.seed <- (171 * random.seed) %% 30269
  random.number[j] <- random.seed / 30269
}

set.seed(1)
runif(10)

set.seed(32078)
runif(10, min = 3, max = 7)


sample(c(3,5,7),size = 2, replace = FALSE)
#[1] 5 7
sample(c(3,5,7),size = 2, replace = FALSE)
#[1] 7 5

sample(letters,size = 2, replace = FALSE)

sample(c("red","white"),size = 100, replace = FALSE)

sample(c("red","white","red","red"),size = 100, replace = FALSE)

set.seed(10)
U2 <- runif(1000)
U1 <- runif(1000)
X <- U1 + U2
Y <- U1 - U2
plot(Y ~ X)
cor(X,Y)


set.seed(1)
out=sample(c("red","white","red","red"),size = 100, replace = T)
table(out)
#  red white 
#   69    31 
out=sample(c("red","white","red","red"),size = 100, replace = T)
table(out)
#  red white 
#   77    23

dbinom(x = 4, size = 6, prob = 0.5)

rbinom(n = 4, size = 6, prob = 0.5)

dpois(x = 3, lambda = 0.5)

N= rpois(20, 1.5*10)

P <- runif(N, max = 10)
sort(P)




#Homework exercises
#5.2 Exercises
#4
set.seed(19908)
U=c(runif(1000))
#a
mean(U)
#[1] 0.496057
var(U)
#[1] 0.08148008
sd(U)
#[1] 0.2854472

#b
#from(a): mean=0.496057,var=0.08148008,sd=0.2854472
#E(x)=(a+b)/2,Var(x)=(b-a)^2/12,SD(x)=sqrt(Var(x))
(0+1)/2
#True mean: 0.5
(1-0)^2/12
#True variance: 0.08333333
sqrt((1-0)^2/12)
#True sd=0.2886751

#c
sum(U<0.6)/length(U)
#[1] 0.59838
#probability of numbers that <0.6: 0.6

#d
1/(0.5+1)
#Estimation: 0.6666667
mean(1/(U+1))
#[1] 0.6946063

#e
hist(U)
hist(1/(U+1)) 


#exercise 6
U1=runif(10000, min = 0, max = 1)
U2=runif(10000, min = 0, max = 1)
#a
#E[U1+U2]
(0+0+1+1)/2
#[1] 1
mean(U1+U2)
#[1] 0.9945047
#E[U1] + E[U2]
(0+1)/2+(0+1)/2
#[1] 1
mean(U1)+mean(U2)
#[1] 0.9945047

#b
var(U1+U2)
#[1] 0.1683181
var(U1)+var(U2)
#[1] 0.1671664
#No, they aren't equal. 
#Yes, the true values should be equal, since U1 and U2 are theoretically independent.

#c
sum((U1+U2)<=1.5)/length(U1)
#[1] 0.8742

#d
sum((sqrt(U1)+sqrt(U2))<=1.5)/length(U1)
#[1] 0.6575


#5.3.3
#exercise 4
set.seed(10)
P5=rpois(10000,5)
P10=rpois(10000,10)
P15=rpois(10000,15)
P20=rpois(10000,20)
#a
mean(sqrt(P5))
#[1] 2.169032
var(sqrt(P5))
#[1] 0.28493
mean(sqrt(P10))
#[1] 3.120297
var(sqrt(P10))
#[1] 0.252473
mean(sqrt(P15))
#[1] 3.836265
var(sqrt(P15))
#[1] 0.2563966
mean(sqrt(P20))
#[1] 4.434638
var(sqrt(P20))
#[1] 0.2578104

#b 
#The effect from (a) shows that the mean still increases steadily 
#in accordance with X; however, the variance stays close to 0.25.
#If variance is stabilized, we can predict the variance of the 
#population regardless of the population mean, making it easier to
#improve the accuracy of estimations.


#The effect of taking a square root on X are that the variance
# decreases slowly as the mean increases.

#5.3.4
#exercise 5
poissonproc <- function(){
  X <- rexp(1000,2.5)
  cx <- cumsum(X)
  s <- sum(cx<=2)
  s
}
set.seed(10)
pp <- replicate(10000,poissonproc())
pd <- rpois(10000,5)
par(mfrow=c(1,2))
hist(pp)
hist(pd)




#ANSWER
# 5.2 exercise 4
set.seed(19908)
U = runif(1000)

#(a)
mean(U)
# 0.496057
var(U)
# 0.08148008
sd(U)
# 0.2854472

#(b)
true.meam = (0+1)/2
true.var = (1-0)^2/12
true.sd = sqrt(true.var)
compare = data.frame(sample = c(mean,var,sd), population = c(true.meam,true.var,true.sd))
row.names(compare) = c("mean","var","sd")
compare

#(c)
p.less.0.6.sample = length(U[U<0.6])/length(U)
p = punif(0.6)
compare = matrix(c(p.less.0.6.sample,p))
rownames(compare) = c("proportion of samples less than 0.6","P(U<0.6)")
compare

#(d)
mean(1/(U+1))
#0.6946063

#(e)
hist(U)
hist(1/(U+1))

# 5.2 exercise 6
U1 = runif(10000)
U2 = runif(10000)

#(a)
compare = matrix(c(mean(U1+U2),0.5+0.5,mean(U1)+mean(U2)))
row.names(compare) = c("E[U1+U2]","True.value","E[U1]+E[U2]")
compare

#(b)
compare = matrix(c(var(U1+U2),var(U1)+var(U2)))
row.names(compare) = c("Var[U1+U2]","Var[U1]+E[U2]")
compare
#No, they aren't equal. 
#Yes, the true values should be equal, since U1 and U2 are theorectically independent.

#(c)
sum = U1+U2
length(sum[sum <= 1.5])/length(sum)
#0.8792

#(d)
sqr.sum = sqrt(U1)+sqrt(U2)
length(sqr.sum[sqr.sum <= 1.5])/length(sqr.sum)
#0.6582

#5.3.3 Exercise 4
set.seed(10)
P5 = rpois(10000,5)
P10 = rpois(10000,10)
P15 = rpois(10000,15)
P20 = rpois(10000,20)

#(a)
P =list(P5,P10,P15,P20)
e.sqrx = numeric(4)
var.sqrx = numeric(4)
row.names = numeric(4)
for(p in 1:length(P)){
  e.sqrx[p] = mean(sqrt(P[[p]]))
  var.sqrx[p] = var(sqrt(P[[p]]))
  row.names[p] = round(mean(P[[p]]))
}
res = matrix(c(e.sqrx,var.sqrx),nrow = 4,ncol = 2)
rownames(res) = paste("lamda=",row.names)
colnames(res) = c("E[sqrt(X)]","Var[sqrt(X)]") 
as.table(res)
#(b)
#The effect of taking a square root on X are that the variance
# decreases slowly as the mean increases.

#5.3.4 Exercise 5
# Method 1
count <- numeric(10000)
for(i in 1:10000){
  cum <- 0
  j <- 0
  while(cum <= 2){
    j <- j + 1
    r <- rexp(1, rate=2.5)
    cum <- cum + r
  }
  count[i] <- j - 1
}
hist(count,probability = T,ylim=c(0,0.22),main="Poisson process with rate 2.5")
lines(0:15,dpois(0:15,5),col=2,type="b")
legend("topright",legend=c("Pmf of Poi(5)"),lty=1,pch=1,col=2)

# Method 2
poissonproc <- function(){
  X <- rexp(1000,2.5)
  cx <- cumsum(X)
  s <- sum(cx<=2)
  s
}
set.seed(10)
pp <- replicate(10000,poissonproc())
pd <- rpois(10000,5)
par(mfrow=c(1,2))
hist(pp)
hist(pd)
