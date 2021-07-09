set.seed(10)
X1=rexp(100000,rate=1/3)
X2=rexp(100000,rate=1/6)
x1x2=pmin(X1,X2)
mean(x1x2)
#[1] 2.002317
var(x1x2)
#[1] 4.003281

x=rnorm(10000)
x=x[(x>0)&(x<3)]
hist(s,prob-T)

#P(X<1.96)
sum(x<1.96)/length(x)


X=rnorm(10000,3,4)
X=X[(X>2)|(X<(-2))]
hist(X, prob=T)

X=rnorm(10000,3,4)
X=X[(abs(X)>2)]
hist(X, prob=T)
  
set.seed(1)
u=runif(1000000)
mean(u^4)
#[1] 0.1998337

set.seed(1)
u=runif(1000000,min=2,max=5)
mean(sin(u))*(5-2)
#[1] -0.699702



#Approximate the integral {10-3} {7-1} sin(x − y) dx dy using the following:
U <- runif(10000000, min = 1, max = 7)
V <- runif(10000000, min = 3, max = 10)
mean(sin(U - V))*42
#[1] 0.1272321


X <- rexp(100000)
mean( exp( -(X + 1)^2 ) / dexp(X) )
#[1] 0.1392751

U1 <- runif(100000, max=2)
U2 <- runif(100000)
X <- U1[U2 < (1 - abs(1 - U1))]
hist(X,prob=T)

x=seq(0,4,length=50)
plot(x,exp(-x),type='l')
lines(x,0.5*exp(-x^1.5),lty=2)


kg <- function(x) 0.5*exp(-(x^1.5))
X <- rexp(100000)
U <- runif(100000)
X=X[U*dexp(X)<kg(X)]
k=length(X)
hist(X,freq=F,breaks="Scott")

#k=0.5/C
#C=0.5/k
C=0.5/(length(X)/100000)
#[1] 1.108402

hist(X,freq=F,breaks="Scott")
fbyk=function(x) dexp(x)/k
curve(fbyk, from=0, to=max(X), add=TRUE, lty=2)

 
g=function(x) C*0.5*exp(-(x^1.5))
X=rexp(100000)
W=g(X)/dexp(X)
mean.w=weighted.mean(X,W)
mean.w
#[1] 0.6586056
var.w=weighted.mean((X-mean.w)^2,W)
var.w
#[1] 0.3035116





#Homework
#5.4 
#Exercise 1
#Formula 6
x=rexp(1000000)
mean(exp((-x)^3)/dexp(x))
#[1] 0.8941121
#The true value is approximately 0.8929795

#Formula 7
x=runif(1000000, 0, 3)
mean(sin(exp(x)))*3
#[1] 0.6089041
#The true value is approximately 0.6061244

#Formula 10
x=runif(1000000, 0, 3)
pi=3.1415926
mean(exp(-x^2/2)/sqrt(2*pi))*3
#[1] 0.4990142
#The true value is approximately 0.4986501

#Exercise 2
#Formula 3
x <- runif(1000000, min = 0, max = 1)
y <- runif(1000000, min = 0, max = 3)
mean(cos(x - y))*3
#[1] 1.033662

#Formula 4
x <- runif(1000000, min = 0, max = 2)
y <- runif(1000000, min = 0, max = 5)
mean(exp(-(x+y)^2)*(x+y)^2)*10
#[1] 0.4931703 


#5.5.2 
#Exercise 1
rand.normal <- function(n){
  r1 <- runif(n, min = -4, max = 4)
  r2 <- runif(n)
  ans <- r1[ r2 < 2.5*dnorm(r1)]
  while(length(ans) < n){
    r1 <- runif(n, min = -4, max = 4)
    r2 <- runif(n)
    ans <- c(ans,r1[ r2 < 2.5*dnorm(r1)])
  }
  return(ans[1:n])
}
hist(rand.normal(1000),probability =T)
lines(seq(-10,10,0.1),dnorm(seq(-10,10,0.1)))


#Exercise 3
probs <- c(0.2, 0.3, 0.1, 0.15, 0.05, 0.2)
rd1 <- function(n, probs) {
  cumprobs <- cumsum(probs)
  singlenumber <- function() {
    x <- runif(1)
    N <- sum(x > cumprobs)
    N
  }
  replicate(n, singlenumber())
}
rd2 <- function(n, probs) {
  singlenumber <- function() {
    repeat{
      U=runif(2,c(-0.5,0),c(length(probs)-0.5,max(probs)))
      if (U[2] < probs[round(U[1]) + 1]) break
    }
  return(round(U[1]))
  }
  replicate(n, singlenumber())
}
system.time(rd1(100,probs))
#  user  system elapsed 
#  0       0       0 
system.time(rd2(100,probs))
#  user  system elapsed 
#  0       0       0 
system.time(rd1(1000,probs))
#   user  system elapsed 
#   0.02    0.00    0.01 
system.time(rd2(1000,probs))
#   user  system elapsed 
#   0.02    0.00    0.01 
system.time(rd1(10000,probs))
#   user  system elapsed 
#   0.03    0.00    0.04 
system.time(rd2(10000,probs))
#   user  system elapsed 
#   0.08    0.00    0.08 

#The first method is faster


# Chapter5 Exercise 1
#(a)
hitBall <- function(probSuccess) {
  rbinom(1, 1, probSuccess)
}

rally <- function(probs, hitter = 1) {
  serve <- 1
  while (serve == 1) {
    serve <- hitBall(probs[hitter])
    hitter <- 3 - hitter
  }
  hitter
}

game <- function(successProbs = c(.5, .5), winningScore = 11, initialServer = 1) {
  score <- c(0, 0)
  server <- initialServer
  while (max(score) < max(11, min(score) + 2)) {
    winner <- rally(successProbs, server)
    score[winner] <- score[winner] + 1
    if (sum(score) %% 2 == 0) server <- 3 - server
  }
  score
}

game()

#(b)
rally <- function(probs, hitter = 1, serveProbs) {
  serve <- 1
  serve <- hitBall(serveProbs[hitter])
  hitter <- 3 - hitter
  while (serve == 1) {
    serve <- hitBall(probs[hitter])
    hitter <- 3 - hitter
  }
  hitter
}
game <- function(successProbs = c(0.5, 0.5), winningScore = 11, initialServer = 1, serveProbs = c(0.75, 0.75)) {
  score <- c(0, 0)
  server <- initialServer
  while (max(score) < max(11, min(score) + 2)) {
    winner <- rally(successProbs, server, serveProbs)
    score[winner] <- score[winner] + 1
    if (sum(score) %% 2 == 0) server <- 3 - server
  }
  score
}

game()






#ANSWER
# 5.4 Exercise 1
#Formula 6
x <- rexp(100000)
mean(exp(-(x) ^ 3) / dexp(x))
#[1] 0.8933416
#The true value is approximately 0.8929795

#Formula 7
x <- runif(100000, min = 0, max = 3)
mean(sin(exp(x))) * (3 - 0)
#[1] 0.6138232
#The true value is approximately 0.6061244

#Formula 10
x <- runif(100000, min = 0, max = 3)
mean(dnorm(x, mean = 0, sd = 1)) * (3 - 0)
#[1] 0.4988686
#The true value is approximately 0.4986501

# 5.4 Exercise 2
#Formula 3
x <- runif(100000, min = 0, max = 1)
y <- runif(100000, min = 0, max = 3)
mean(cos(x - y)) * (3 - 0) * (1 - 0)
#[1] 1.031458

#Formula 4
x <- runif(100000, min = 0, max = 2)
y <- runif(100000, min = 0, max = 5)
mean(exp(-(y + x) ^ 2) * ((x + y) ^ 2)) * (2 - 0) * (5 - 0)
#[1] 0.4938012


# 5.5.2 Exercise 1
rand.normal <- function(n){
  r1 <- runif(n, min = -4, max = 4)
  r2 <- runif(n)
  ans <- r1[ r2 < 2.5*dnorm(r1)]
  while(length(ans) < n){
    r1 <- runif(n, min = -4, max = 4)
    r2 <- runif(n)
    ans <- c(ans,r1[ r2 < 2.5*dnorm(r1)])
  }
  return(ans[1:n])
}
hist(rand.normal(1000),probability =T)
lines(seq(-10,10,0.1),dnorm(seq(-10,10,0.1)))


# 5.5.2 Exercise 3
probs = c(0.2,0.3,0.1,0.15,0.05,0.2)
randiscrete1 = function(n,probs){
  cumprobs = cumsum(probs)
  singlenumber = function(){
    x = runif(1)
    N = sum(x > cumprobs) 
    N
  }
  replicate(n,singlenumber())
}

randiscrete2 = function(n,probs){
  singlenumber = function(){
    repeat{
      U = runif(2,min = c(-0.5,0),max = c(length(probs)-0.5,max(probs)))
      if(U[2] <　probs[round(U[1])+1]) break
    }
    return(round(U[1]))
  }
  replicate(n,singlenumber())
}

system.time(randiscrete1(n=100,probs = probs))
#user  system elapsed 
#0       0       0 
system.time(randiscrete2(n=100,probs = probs))
#user  system elapsed 
#0       0       0 

system.time(randiscrete1(n=1000,probs = probs))
#user  system elapsed 
#0.01    0.00    0.02
system.time(randiscrete2(n=1000,probs = probs))
#user  system elapsed 
#0.01    0.00    0.02

system.time(randiscrete1(n=10000,probs = probs))
# user  system elapsed 
#0.02    0.00    0.02 
system.time(randiscrete2(n=10000,probs = probs))
# user  system elapsed 
#0.08    0.00    0.08 

#The first method is faster

# Chapter5 Exercise 1
#(a)
hitBall <- function(probSuccess) {
  rbinom(1, 1, probSuccess)
}

rally <- function(probs, hitter = 1) {
  serve <- 1
  while (serve == 1) {
    serve <- hitBall(probs[hitter])
    hitter <- 3 - hitter
  }
  hitter
}

game <- function(successProbs = c(.5, .5), winningScore = 11, initialServer = 1) {
  score <- c(0, 0)
  server <- initialServer
  while (max(score) < max(11, min(score) + 2)) {
    winner <- rally(successProbs, server)
    score[winner] <- score[winner] + 1
    if (sum(score) %% 2 == 0) server <- 3 - server
  }
  score
}

game()

#(b)
rally <- function(probs, hitter = 1, serveProbs) {
  serve <- 1
  serve <- hitBall(serveProbs[hitter])
  hitter <- 3 - hitter
  while (serve == 1) {
    serve <- hitBall(probs[hitter])
    hitter <- 3 - hitter
  }
  hitter
}
game <- function(successProbs = c(0.5, 0.5), winningScore = 11, initialServer = 1, serveProbs = c(0.75, 0.75)) {
  score <- c(0, 0)
  server <- initialServer
  while (max(score) < max(11, min(score) + 2)) {
    winner <- rally(successProbs, server, serveProbs)
    score[winner] <- score[winner] + 1
    if (sum(score) %% 2 == 0) server <- 3 - server
  }
  score
}

game()

