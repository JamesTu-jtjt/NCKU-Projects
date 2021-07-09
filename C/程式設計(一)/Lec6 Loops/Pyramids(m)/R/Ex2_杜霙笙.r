some.evens<-NULL
some.evens
some.evens[seq(2, 30, 3)]<-seq(2,30,3)
some.evens
#[1] NA  2 NA NA  5 NA NA  8 NA NA 11 NA NA 14 NA NA 17 NA NA 20 NA NA 23
#[24] NA NA 26 NA NA 29

x=c(2,0,8)
x/x
#[1]   1 NaN   1

y=rep(1,3)
x=c(2,0,8)
y/x
#[1] 0.500   Inf 0.125

1/(y/x)
#[1] 2 0 8

x[0.5]
#numeric(0)

colors <- c("red", "yellow","blue")
more.colors <- c(colors, "green","magenta", "cyan")

x=c("red","blue",1)
x
#[1] "red"  "blue" "1"   
2*x[3]
#Error in 2 * x[3] : ?G???B???l?????D?ƭȤ޼?
2*as.numeric(x[3])
#[1] 2

substr(colors,1,2)
#[1] "re" "ye" "bl"
substr(colors,2,3)
#[1] "ed" "el" "lu"
?substr
substring("abcdef",1:6,1:6)
#[1] "a" "b" "c" "d" "e" "f"
substring("abcdef",1:5,rep(2,5))
#[1] "ab" "b"  ""   ""   ""  
substring("abcdef",1:5,rep(5,5))
#[1] "abcde" "bcde"  "cde"   "de"    "e" 

paste(colors,"flowers")
#[1] "red flowers"    "yellow flowers" "blue flowers"  

paste("I don't like",colors,collapse="!!!!!")
#[1] "I don't like red!!!!!I don't like yellow!!!!!I don't like blue"

grp <- c("control","treatment","control","treatment")
grp
#[1] "control"   "treatment" "control"   "treatment"

class(grp)
#[1] "character"

grp<-factor(grp)
grp
#[1] control   treatment control   treatment
#Levels: control treatment
as.integer(grp)
#[1] 1 2 1 2
class(grp)
#[1] "factor"

levels(grp)
#[1] "control"   "treatment"
levels(grp)[as.integer(grp)]
#[1] "control"   "treatment" "control"   "treatment"


grp[3]
exp=levels(grp)[as.integer(grp)]
exp
#[1] "control"   "treatment" "control"   "treatment"
exp.factor=grp[as.integer(grp)]
exp.factor
#[1] control   treatment control   treatment
#Levels: control treatment

table(exp)
#exp
#control treatment 
#2         2 

table(exp.factor)
#exp.factor
#control treatment 
#2         2 

table(exp[c(2,4)])
#treatment 
#2 
table(exp.factor[c(2,4)])
#control treatment 
#0         2 

is.na(some.evens)
# [1]  TRUE FALSE  TRUE  TRUE FALSE  TRUE  TRUE FALSE  TRUE  TRUE FALSE  TRUE  TRUE
#[14] FALSE  TRUE  TRUE FALSE  TRUE  TRUE FALSE  TRUE  TRUE FALSE  TRUE  TRUE FALSE
#[27]  TRUE  TRUE FALSE
!is.na(some.evens)
# [1] FALSE  TRUE FALSE FALSE  TRUE FALSE FALSE  TRUE FALSE FALSE  TRUE FALSE FALSE
#[14]  TRUE FALSE FALSE  TRUE FALSE FALSE  TRUE FALSE FALSE  TRUE FALSE FALSE  TRUE
#[27] FALSE FALSE  TRUE

some.evens[!is.na(some.evens)]
#[1]  2  5  8 11 14 17 20 23 26 29

m <- matrix(1:6,nrow=2,ncol=3)
m
m[1,2]
m[5]
#[1] 5
m[1,]
m[,3]

a <- array(1:24,c(3,4,3))
a
a[3,4,3]
a[,,1]
a[,1,]
a[,1,1:2]

colors <- c("red", "yellow","blue")
numbers<-c(1,2,3)
colors.and.numbers<-data.frame(colors,numbers,more.numbers=c(4,5,6))
colors.and.numbers

###############################################################
#Exercise
170166719%%31079
#[1] 9194
n=c(10,20,30,40)
r=rep(c(1.08,1.06),each=4)
(1-r^(n+1))/(1-r)
#[1]  16.64549  50.42292 123.34587 280.78104  14.97164  39.99273  84.80168
#[8] 165.04768

r2=c(1.08,1.06)
cumsum(1:5)
#[1]  1  3  6 10 15
out.v=cumsum(r2^(1:n[4]))
out.v

##############################################################

?strptime
Sys.time()
#[1] "2020-09-18 09:27:24 CST"
format(Sys.time(), "%a %b %d %X %Y %Z")
#[1] "?g?? ?E?? 18 ?W?? 09:30:26 2020 CST"
x <- c("1jan1960", "2jan1960", "31mar1960", "30jul1960")
z <- strptime(x, "%d%b%Y")
## Sys.setlocale("LC_TIME", lct)
z

## read in date/time info in format 'm/d/y h:m:s'
dates <- c("02/27/92", "02/27/92", "01/14/92", "02/28/92", "02/01/92")
times <- c("23:03:20", "22:29:56", "01:03:30", "18:21:03", "16:56:26")
x <- paste(dates, times)
out=strptime(x, "%m/%d/%y %H:%M:%S")
class(dates)
class(times)
class(out)

?ISOdate
ISOdate(year=2020, month=9, day=18, hour = 9, min = 34, sec = 0, tz = "GMT")

example(mean)

help.search("optimization")

x<- c(12,15,13,20,14,16,10,10,8,15)
hist(x)
?hist
out=hist(x,plot=F)
out

x<-seq(1,10)
y<-x^3-10*x
plot(x,y)

x<-rnorm(10000)+rnorm(10000,m=1,sd=0.1)
hist(x)
x<-c(rnorm(10000),rnorm(10000,m=5,sd=0.1))
hist(x,breaks=100)

curve(expr=sin,from=0,to=6*pi)

x=seq(0.6*pi,length=50)
y=sin(x)
plot(x,y)
plot(x,y, type="l")

####################################################
#Homework2
#2.
r=0.003
n=300
principle=200000
payment=principle*r/(1-(1+r)^(-n))
payment
# output: 1012.005



#exercise7
n=c(200,400,600,800)
n*(n+1)*(2*n+1)/6
#[1]   2686700  21413400  72180100 170986800

#exercise8
n<-c(1:100)
v<-n*(n+1)*(2*n+1)/6
v
# #[1]      1      5     14     30     55     91    140
# [8]    204    285    385    506    650    819   1015
# [15]   1240   1496   1785   2109   2470   2870   3311
# [22]   3795   4324   4900   5525   6201   6930   7714
# [29]   8555   9455  10416  11440  12529  13685  14910
# [36]  16206  17575  19019  20540  22140  23821  25585
# [43]  27434  29370  31395  33511  35720  38024  40425
# [50]  42925  45526  48230  51039  53955  56980  60116
# [57]  63365  66729  70210  73810  77531  81375  85344
# [64]  89440  93665  98021 102510 107134 111895 116795
# [71] 121836 127020 132349 137825 143450 149226 155155
# [78] 161239 167480 173880 180441 187165 194054 201110
# [85] 208335 215731 223300 231044 238965 247065 255346
# [92] 263810 272459 281295 290320 299536 308945 318549
# [99] 328350 338350

#exercise11
rep(seq(1,4,by=1),each=5)
#[1] 0 0 0 0 0 1 1 1 1 1 2 2 2 2 2 3 3 3 3 3 4 4 4 4 4
rep(seq(1,5,by=1),5)
#[1] 1 2 3 4 5 1 2 3 4 5 1 2 3 4 5 1 2 3 4 5 1 2 3 4 5

#exercise12
rep(c(1:5),5)+rep(c(0:4),each=5)
#[1] 1 2 3 4 5 2 3 4 5 6 3 4 5 6 7 4 5 6 7 8 5 6 7 8 9

#exercise13
colors <- c("red", "yellow","blue")
more.colors <- c(colors, "green","magenta", "cyan")
more.colors[rep(c(1:3),4)+rep(c(0:3),each=3)]
# [1] "red"     "yellow"  "blue"    "yellow"  "blue"   
#[6] "green"   "blue"    "green"   "magenta" "green"  
#[11] "magenta" "cyan"   


#ANSWER
#2.
r=0.003
n=300
principle=200000
payment=principle*r/(1-(1+r)^(-n))
payment
# output: 1012.005

#7.
# Summation 
n=c(200,400,600,800)
cumsum((1:n[4])^2)[n]
# output:2686700,21413400,72180100,170986800

# Calculate Function
n*(n+1)*(2*n+1)/6
# output:2686700,21413400,72180100,170986800

#8.
n <- 1:100
out.v <- c(n*(n+1)*(2*n+1)/6)

# output:
#       1      5     14     30     55     91    140    204    285    385
#     506    650    819   1015   1240   1496   1785   2109   2470   2870
#    3311   3795   4324   4900   5525   6201   6930   7714   8555   9455
#   10416  11440  12529  13685  14910  16206  17575  19019  20540  22140
#   23821  25585  27434  29370  31395  33511  35720  38024  40425  42925
#   45526  48230  51039  53955  56980  60116  63365  66729  70210  73810
#   77531  81375  85344  89440  93665  98021 102510 107134 111895 116795
#  121836 127020 132349 137825 143450 149226 155155 161239 167480 173880
#  180441 187165 194054 201110 208335 215731 223300 231044 238965 247065
#  255346 263810 272459 281295 290320 299536 308945 318549 328350 338350
#11.
rep(seq(0,4,1),rep(5,5))
# output: 0 0 0 0 0 1 1 1 1 1 2 2 2 2 2 3 3 3 3 3 4 4 4 4 4

rep(c(1,2,3,4,5),5)
# output: 1 2 3 4 5 1 2 3 4 5 1 2 3 4 5 1 2 3 4 5 1 2 3 4 5

#12.
rep(0:4,each=5)+1:5
# output: 1 2 3 4 5 2 3 4 5 6 3 4 5 6 7 4 5 6 7 8 5 6 7 8 9

#13.
colors <- c("red", "yellow", "blue")
more.colors <- c(colors, "green", "magenta", "cyan")
more.colors[seq(1,3)+ rep(0:3,each=3)]
# output:"red"    "yellow"  "blue"    "yellow"  "blue"    "green"   
#        "blue"   "green"   "magenta" "green"   "magenta" "cyan"   

