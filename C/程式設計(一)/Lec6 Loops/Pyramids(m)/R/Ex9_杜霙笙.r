size.v=c(5,10,20,30,50)
set.seed(10)
old.par=par(mfrow=c(5,5),mar=c(2,2,2,1),mgp=c(1,0.5,0))
for (i in 1:length(size.v)){
  for (j in 1:5){
    sample.v=rnorm(size.v[i])
    p=shapiro.test(sample.v)$p.value
    qqnorm(sample.v,main=paste("Sample size",size.v[i]," Sim= ",j,"P-value=",round(p,3)),
           cex=0.6,cex.main=0.8,cex.lab=0.7,cex.axis=0.7)
    qqline(sample.v)
  }
}


shapiro.test(rnorm(10))

#central limit thm

size.v=c(5,10,20,30,50,100)
n.sim=100
set.seed(10)
old.par=par(mfrow=c(3,2),mar=c(2,2,2,1),mgp=c(1,0.5,0))
for (i in 1:length(size.v)){
  standard.v=rep(0,n.sim)
  for (j in 1:n.sim){
    sample.v=rexp(size.v[i])
    standard.v[j]=sqrt(size.v[i])*(mean(sample.v)-1)/sqrt(var(sample.v))
  }
    p=shapiro.test(standard.v)$p.value
    qqnorm(standard.v,main=paste("Sample size",size.v[i]," Sim= ",j,"P-value=",round(p,3)),
           cex=0.6,cex.main=0.8,cex.lab=0.7,cex.axis=0.7)
    qqline(standard.v)
}


#X~Bin(10,p=0.2)
#Sim.n=200
#Sample size: 5,10,20,30,40,50,100,200,500
size.v=c(5,10,20,30,40,50,100,200,500)
set.seed(100)
n.sim=200
old.par=par(mfrow=c(3,3),mar=c(2,2,2,1),mgp=c(1,0.5,0))
for (i in 1:length(size.v)){
  standard.v=rep(0,n.sim)
  for (j in 1:n.sim){
    sample.v=rbinom(size.v[i],10,prob=0.2)
    standard.v[j]=sqrt(size.v[i])*(mean(sample.v)-2)/sqrt(var(sample.v))
  }
    p=shapiro.test(standard.v)$p.value
    qqnorm(standard.v,main=paste("Sample size",size.v[i],"P-value=",round(p,3)),
           cex=0.6,cex.main=0.8,cex.lab=0.7,cex.axis=0.7)
    qqline(standard.v)
}


#=============================================================================================
H3 <- matrix(c(1, 1/2, 1/3, 1/2, 1/3, 1/4, 1/3, 1/4, 1/5), nrow=3)
H3

cbind(seq(1, 3), seq(2, 4), seq(3, 5))
1/cbind(seq(1, 3), seq(2, 4), seq(3, 5))

X=matrix(seq(1, 12), nrow=3)
class(X[3, , drop = FALSE])
#[1] "matrix" "array"
class(X[3,])
#[1] "integer"

H3 <- matrix(c(1, 1/2, 1/3, 1/2, 1/3, 1/4, 1/3, 1/4, 1/5), nrow=3)
H3
rownames(H3)=c("A","B","C")
colnames(H3)=c("Red","Blue","Yellow")
H3

H3[c("B","C"),"Yellow"]

H3.fr=as.data.frame(H3)
H3.fr$Red
#[1] 1.0000000 0.5000000 0.3333333
H3.fr$A
#NULL

dim(H3)
det(H3)
diag(H3)

trace=function(data) sum(diag(data))

trace(H3)

diag(diag(H3))
#     [,1]      [,2] [,3]
#[1,]    1 0.0000000  0.0
#[2,]    0 0.3333333  0.0
#[3,]    0 0.0000000  0.2

diag(c(1,2,3))

summary(H3)

summary(H3.fr)

set.seed(10)
M=matrix(rnorm(16),nrow=4)
out=c(det(M),det(t(M)))
out

lower.tri(H3)
H3[lower.tri(H3)]

Hnew=H3
Hnew[upper.tri(H3,diag=T)]=0
Hnew
#        Red Blue Yellow
#A 0.0000000 0.00      0
#B 0.5000000 0.00      0
#C 0.3333333 0.25      0

2*H3

Hnew+H3

t(H3[,c(1,3)])
#               A    B         C
#Red    1.0000000 0.50 0.3333333
#Yellow 0.3333333 0.25 0.2000000

t(H3[,c(1,3)])+H3[,c(1,3)]
#Error in t(H3[, c(1, 3)]) + H3 : 非調和陣列

t(H3[,c(1,3)])%*%(H3[,c(1,3)])
#         [,1]      [,2]
#[1,] 1.361111 0.5250000
#[2,] 0.525000 0.2136111

H3[,c(1,3)]^2
#        Red    Yellow
#A 1.0000000 0.1111111
#B 0.2500000 0.0625000
#C 0.1111111 0.0400000

H3%*%H3
#       Red      Blue    Yellow
#A 1.361111 0.7500000 0.5250000
#B 0.750000 0.4236111 0.3000000
#C 0.525000 0.3000000 0.2136111

crossprod(H3[,c(1,3)],H3[,c(1,3)])
#            Red    Yellow
#Red    1.361111 0.5250000
#Yellow 0.525000 0.2136111


H3inv<-solve(H3)
H3inv%*%H3

b=c(1,2,3)
x=solve(H3,b)

eigen(H3)


#===============================================================================
#Homework
#problem 1
t=runif(1000000,6,7)
u=runif(1000000,7,8)
v=runif(1000000,8,9)
w=runif(1000000,9,10)
x=runif(1000000,10,11)
y=runif(1000000,1,2)
z=runif(1000000,2,4)
a=runif(1000000,4,8)
b=runif(1000000,3,6)
c=runif(1000000,5,10)
mean((t+u+v+w+x)*(y+z+a+b+c)^(1/5))*2*3*4*5
#[1] 9499.321

#problem 2
#(1)
x1=runif(10000,0,6)
x2=runif(10000,2,4)
y=x1+x2
hist(y)
plot(density(y))

#(3)
Y=function(size){
  x1=runif(size,0,6)
  x2=runif(size,2,4)
  return(x1+x2)
}
size.v=c(5,10,30,100)
n.sim=100
set.seed(10)
old.par=par(mfrow=c(2,2),mar=c(2,2,2,1),mgp=c(1,0.5,0))
for (i in 1:length(size.v)){
  standard.v=rep(0,n.sim)
  for (j in 1:n.sim){
    sample.v=Y(size.v)
    standard.v[j]=sqrt(size.v[i])*(mean(sample.v)-6)/sqrt(var(sample.v))
  }
  p=shapiro.test(standard.v)$p.value
  qqnorm(standard.v,main=paste("Sample size",size.v[i]," Sim= ",j,"P-value=",round(p,3)),
         cex=0.6,cex.main=0.8,cex.lab=0.7,cex.axis=0.7)
  qqline(standard.v)
}


#6.3 exercise 1~5
#1
X <- matrix(c(1, 2, 3, 1, 4, 9), ncol=2)
H=X%*%solve(t(X)%*%X)%*%t(X)
H
#           [,1]      [,2]       [,3]
#[1,]  0.5263158 0.4736842 -0.1578947
#[2,]  0.4736842 0.5263158  0.1578947
#[3,] -0.1578947 0.1578947  0.9473684

#2
eigen(H)
#$values
#[1] 1.000000e+00 1.000000e+00 6.661338e-16 (last eigenvalue close to 0)

#$vectors
#          [,1]       [,2]       [,3]
#[1,] 0.0000000 -0.7254763  0.6882472
#[2,] 0.3162278 -0.6529286 -0.6882472
#[3,] 0.9486833  0.2176429  0.2294157

#3
trace = function(data) sum(diag(data))
trace(H)
#[1] 2
sum(eigen(H)$values)
#[1] 2

#4
det(H)
#[1] -1.752984e-17 (close to 0)
prod(eigen(H)$values)
#[1] 6.661338e-16 (close to 0)
as.integer(det(H))
#[1] 0
as.integer(prod(eigen(H)$values))
#[1] 0

#5
#5.
I = diag(rep(1,3))
X
I-H

#eigen(H)$values
#[1] 1.000000e+00 1.000000e+00 6.661338e-16
# The eigen values are 1, 1, and 0

# X
# column 1
H%*%(X[,1])
X[,1]
# The first column of X is an eigenvector of H with eigenvalue 1.

# column 2
H%*%(X[,2])
X[,2]
# The second column of X is an eigenvector of H with eigenvalue 1.

# I-H
H%*%(I-H)
#              [,1]          [,2]          [,3]
#[1,] -8.222589e-16 -7.875645e-16  3.122502e-17
#[2,] -7.875645e-16 -1.099815e-15 -8.864437e-16
#[3,]  1.110223e-16 -8.326673e-16 -2.803313e-15

# Since each column of H%*%(I-H) is a zero-vector, 
#I-H are eigenvectors of H with eigenvaue 0.



I3=matrix(c(1,0,0,0,1,0,0,0,1),ncol=3)
H1=I3-H
#H*x=eigenvalue*x (x=eigenvector)
H%*%H1[,1]
6.661338e-16*H1[,1,drop=F]
H%*%H1[,2,drop=F]
6.661338e-16*H1[,2,drop=F]
H%*%H1[,3]
6.661338e-16*H1[,3,drop=F]
#all significantly close to 0

as.integer(H%*%H1[,1])
#[1] 0 0 0
as.integer(6.661338e-16*H1[,1,drop=F])
#[1] 0 0 0
as.integer(H%*%H1[,2])
#[1] 0 0 0
as.integer(6.661338e-16*H1[,2,drop=F])
#[1] 0 0 0
as.integer(H%*%H1[,3])
#[1] 0 0 0
as.integer(6.661338e-16*H1[,3,drop=F])
#[1] 0 0 0
H%*%X[,1]
#     [,1]
#[1,]    1
#[2,]    2
#[3,]    3
1*X[,1,drop=F]
#     [,1]
#[1,]    1
#[2,]    2
#[3,]    3
H%*%X[,2]
#     [,1]
#[1,]    1
#[2,]    4
#[3,]    9
1*X[,2,drop=F]
#     [,1]
#[1,]    1
#[2,]    4
#[3,]    9





#ANSWER
#Problem 1
# Solution 1
X = matrix(nrow = 100000,ncol = 10)
set.seed(10)
index = 1

for(f in 11:7){
  i = f-1
  X[,index] = runif(100000,min=i,max=f)
  index=index+1
}

for(f in seq(2,10,by=2)){
  i = f/2
  X[,index] = runif(100000,min=i,max=f)
  index=index+1
}


mean((X[,1]+X[,2]+X[,3]+X[,4]+X[,5])*(X[,6]+X[,7]+X[,8]+X[,9]+X[,10])^(1/5))*120
# 9498.237

# Solution 2

integral.range.m=matrix(c(10:1,11:7,seq(10,2,-2)),ncol=2)
area=prod(integral.range.m[,2]-integral.range.m[,1])
fun.f=function(x){
  sum(x[1:5])*(sum(x[6:10])^(1/5))
}
set.seed(2)
x.m=matrix(0,nrow=100000,ncol=10)
for (i in 1:10){
  x.m[,i] = runif(100000,min=integral.range.m[i,1],max=integral.range.m[i,2])
}
mean(apply(x.m,1,fun.f))*area
#[1] 9499.995


#Problem 2
#(1)
set.seed(10)
X1 = runif(100000,0,6)
X2 = runif(100000,2,4)
Y = X1+X2
plot(density(Y))

#(2)
size.v = c(5,10,30,100)
set.seed(100)
n.sim = 200
old.par = par(mfrow = c(2,2),mar = c(3,3,2,1),mgp = c(1.5,0.5,0))
for(i in 1:length(size.v)){
  standard.v = rep(0,n.sim)
  for(j in 1:n.sim){
    sample.v = runif(size.v[i],0,6)+runif(size.v[i],2,4)
    standard.v[j] = (mean(sample.v)-6)/(sd(sample.v)/sqrt(size.v[i]))
  }
  p = shapiro.test(standard.v)$p.value
  qqnorm(standard.v,main = paste("Size",size.v[i],"Sim= ",j,"Pvalue= ",round(p,3)),
         cex=0.6,cex.main=0.8,cex.lab=0.7,cex.axis=0.7)
  qqline(standard.v)
}

#Problem 3

#6.3

#1.
X = matrix(c(1,2,3,1,4,9),ncol=2)
H = X%*%solve(t(X)%*% X) %*% t(X)
H

#2.
eigen(H)$vectors

#3.
trace = function(data) sum(diag(data))
trace(H) # 2
sum(eigen(H)$values) # 2
#The trace of H is the same as the sum of the eigenvalues.

#4.
det(H)
prod(eigen(H)$values)
#The determinant of H is the same as the product of the eigenvalues.(Both of them are 0)

#5.
I = diag(rep(1,3))
X
I-H

#eigen(H)$values
#[1] 1.000000e+00 1.000000e+00 6.661338e-16
# The eigen values are 1, 1, and 0

# X
# column 1
H%*%(X[,1])
X[,1]
# The first column of X is an eigenvector of H with eigenvalue 1.

# column 2
H%*%(X[,2])
X[,2]
# The second column of X is an eigenvector of H with eigenvalue 1.

# I-H
H%*%(I-H)
#              [,1]          [,2]          [,3]
#[1,] -8.222589e-16 -7.875645e-16  3.122502e-17
#[2,] -7.875645e-16 -1.099815e-15 -8.864437e-16
#[3,]  1.110223e-16 -8.326673e-16 -2.803313e-15

# Since each column of H%*%(I-H) is a zero-vector, 
#I-H are eigenvectors of H with eigenvaue 0.
