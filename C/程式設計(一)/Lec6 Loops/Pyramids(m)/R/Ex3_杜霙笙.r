#20200923
curve(x^2-10*x,from=1,to=10)

curve(x^6-x^4+x^3-10*x,from=-100,to=100)

summary(rnorm(1000))
#    Min.  1st Qu.   Median     Mean  3rd Qu.     Max. 
#-2.81417 -0.61282  0.06225  0.05351  0.70718  3.46961 

apropos("mean")

x=1:100
sum(1/(100-1)*(x-mean(x))^2)
#[1] 841.6667
sum(1/100*(x-mean(x))^2)
#[1] 833.25
var(x)
#[1] 841.6667

A=c(T,T,F,F)
B=c(T,F,T,F)
!A
#[1] FALSE FALSE  TRUE  TRUE
!B
#[1] FALSE  TRUE FALSE  TRUE
A&B
#[1]  TRUE FALSE FALSE FALSE
A|B
#[1]  TRUE  TRUE  TRUE FALSE

x=1:4
x[A]
#[1] 1 2
x[B]
#[1] 1 3

!(A&B) == (!A)|(!B)
#[1] TRUE TRUE TRUE TRUE
!(A|B) == ((!A)&(!B))
#[1] TRUE TRUE TRUE TRUE

sum(A)
#[1] 2
4*A
#[1] 4 4 0 0

B&(A-2)
#[1]  TRUE FALSE  TRUE FALSE

A&B
A&&B
#[1] TRUE
#&& not vectorized

a=c(1,4,8,9)
a>5
#[1] FALSE FALSE  TRUE  TRUE

a==4
#[1] FALSE  TRUE FALSE FALSE

a!=8
#[1]  TRUE  TRUE FALSE  TRUE
a[a>5]
#[1] 8 9

b=c(2,2,6,6)
a[a>b]
#[1] 4 8 9

getwd()
#[1] "C:/Users/user/Desktop"
setwd("c:/mydata")


usefuldata=1:100
dump("usefuldata","useful.r")

rm(usefuldata)
ls()
source("useful.r")
ls()

dump(list=objects(), "all.R")

source("randomdata.txt")
randomdata
#[1]  64  38  97  88  24  14 104  83
numbers=c(3,5,8,10,12)
dump("numbers","numbers.R")
rm(numbers)
ls()
#[1] "a"           "A"           "b"           "B"          
#[5] "colors"      "more.colors" "n"           "randomdata" 
#[9] "useful"      "usefuldata"  "v"           "x"  

source("numbers.R")
ls()
#[1] "a"           "A"           "b"           "B"          
#[5] "colors"      "more.colors" "n"           "numbers"    
#[9] "randomdata"  "useful"      "usefuldata"  "v"          
#[13] "x"      


#20200925
mat=matrix(1:50,ncol=10)
vec=1:10
sink("mat.txt")
print("matrix")
mat
print("vector")
vec
sink()

save.image("temp.RData")
rm(list=ls())
ls()
load("temp.RData")
ls()

new.mat=read.table("mat.txt")
new.mat
class(new.mat)

new.fr=read.table("mat.txt",header=T)
new.fr

x<-c(3,2,3)
y<-c(7,7)
z=list(x=x,y=y)
z
z=list(x=x,y=y,m=new.fr)
z

w=list(z=z,col=c("red","blue"))
w

list.3layer=list(a=w,b=z)
list.3layer







#HW3
#exercise1
rain.df<-data.frame(read.table("rnf6080.dat", header=F))

#a
rain.df[2,4]

#b
names(rain.df)

#c
rain.df[2,]

#d
names(rain.df)<-c("year","month","day",seq(0,23))
rain.df

#e 
rain.df<-data.frame(rain.df, daily=c(rowSums(rain.df[,4:27])))
names(rain.df)<-c("year","month","day",seq(0,23),"daily")
rain.df
#daily can also be assigned as daily=c(rain.df$'01'+rain.df$'1'+....+rain.df$'23')

#f
x<- c(rain.df$daily)
hist(x)


#exercise2
y<-function(x){(x<=3)*(3*x+2)+(x>3)*(2*x-0.5*x^2)}
curve(y,from=0,to=6)



#===================================================================================

#ANSWER
#1
rain.df<-read.table("http://www.statprogr.science/data/rnf6080.dat",header = FALSE)
rain.df
#(a) display row2 and column 4 of elements
rain.df[2,4]
#[1] 0

#(b) names of columns
names(rain.df)
# [1] "V1"  "V2"  "V3"  "V4"  "V5"  "V6"  "V7"  "V8"  "V9"  "V10" "V11" "V12" "V13" "V14" "V15" "V16" "V17"
#[18] "V18" "V19" "V20" "V21" "V22" "V23" "V24" "V25" "V26" "V27"

#(c) display the second row of data sets
rain.df[2,]
#   V1 V2 V3 V4 V5 V6 V7 V8 V9 V10 V11 V12 V13 V14 V15 V16 V17 V18 V19 V20 V21 V22 V23 V24 V25 V26 V27
#2 60  4  2  0  0  0  0  0  0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0

#(d) re-label columns of data sets
names(rain.df)<-c("year","month","day",seq(0,23))
names(rain.df)
# [1] "year"  "month" "day"   "0"     "1"     "2"     "3"     "4"     "5"     "6"     "7"     "8"    
#[13] "9"     "10"    "11"    "12"    "13"    "14"    "15"    "16"    "17"    "18"    "19"    "20"   
#[25] "21"    "22"    "23"  

#(e) 
rain.df$daily<-rowSums(rain.df[,4:27],na.rm=T)

#(f)
hist(rain.df$daily)

#2
#ans1
curve(3*x+2,from=0,to=3,xlim=c(0,6),ylim=c(-10,15),xlab="x",ylab="y")
par(new=TRUE)
curve(2*x-0.5*(x^2),from=3,to=6,xlim=c(0,6),ylim=c(-10,15),xlab="x",ylab="y")

#ans2
curve((x<=3)*(3*x+2)+(x>3)*(2*x-0.5*(x^2)),from=0,to=6)

#ans3
a = curve(3*x+2, from = 0, to = 3)
b = curve(2*x - 0.5*x^2, from = 3, to = 6)
x = c(a$x, b$x)
y = c(a$y, b$y)
plot(x,y, type= "l")

#ans4
x1=seq(0,3,0.05)
x2=seq(3,6,0.05)
y1=x1*3+2
y2=2*x2-x2*x2/2
x=c(x1,x2)
y=c(y1,y2)
plot(x,y,type="l")









