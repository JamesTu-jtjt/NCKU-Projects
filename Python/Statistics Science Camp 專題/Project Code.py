import numpy as np
import matplotlib.pyplot as plt
import statistics as stat


#initialization of data list
subject_data=[]
#filename="cancer.csv"
#f=open(filename,"r")
path=r'D:\Python Spyder Files\SSC3\cancer.csv'
f=open(path,"r")
f.readline()
for line in f:
	subject_data.append(line.strip())
f.close()
#print(subject_data)


#find total number of subjects
total=len(subject_data)

#create nested lists that represents every subject's data
for i in range(total):
	subject_data[i]=subject_data[i].split(',')
#print(subject_data)


 
#change data type to integer (last column is a string)
for row in range(total):
	for data in range(1,len(subject_data[1])-1):
		subject_data[row][data] = int(subject_data[row][data])
#print(subject_data)


#---count the number of male and female.---#
#initialization
male_count = []
female_count = []
gender = 2 #second column of data
male=1
female=2
for subject in range(total):
	if subject_data[subject][gender] == male:
		male_count.append(subject_data[subject][gender])
	elif subject_data[subject][gender] == female:
		female_count.append(subject_data[subject][gender])
#print result     
print("male amount :",len(male_count))
print("female amount :",len(female_count))
print('\n')

#---mean age of male---#
male_age = []
for subject in range(total):
	if subject_data[subject][gender] == male:
		male_age.append(subject_data[subject][1])
#print mean age
male_mean = sum(male_age)/len(male_count)
print("Average age of male : ", male_mean)


#---variance and standard deviation of age of male---#
#initialization of sum of difference**2
sumvar1 = []
for i in range(len(male_count)):
    tmp = (male_age[i] - male_mean)**2
    sumvar1.append(tmp)
male_variance = (sum(sumvar1)/len(male_count))
male_sd = male_variance**0.5
print('Variance of male age :',male_variance)
print('Standard deviation of male age :',male_sd)
print('\n')


##EXERCISE##
#------mean age of female------#
female_age = []
for subject in range(total):
	if subject_data[subject][gender] == female:
		female_age.append(subject_data[subject][1])
#print mean age
female_mean = sum(female_age)/len(female_count)
print("Average age of female : ",female_mean)

#---variance and standard deviation of age of female---#
sumvar2 = 0
for i in range(len(female_count)):
	sumvar2 = sumvar2 + (female_age[i] - female_mean)**2
female_variance = (sumvar2/len(female_count))
female_sd = female_variance**0.5
print('Variance of female age :',female_variance)
print('Standard deviation of female age:',female_sd)
print('\n')
print('\n')
####


##EXERCISE##
#-----count cancer level-----#
#print(subject_data)
# Low = []
# Medium = []
# High = []
# level= 24
# for subject in range(total):
# 	if subject_data[subject][level] == "Low":
# 		Low.append(subject_data[subject][1])
# 	elif subject_data[subject][level] == "Medium":
# 		Medium.append(subject_data[subject][1])
# 	elif subject_data[subject][level] == "High":
# 		High.append(subject_data[subject][1])
# print("Low level :",len(Low))
# print("Medium level :",len(Medium))
# print("High level :",len(High))
####


#-----count cancer level-----#
Low = 0
Medium = 0
High = 0
level= 24
for subject in range(total):
	if subject_data[subject][level] == "Low":
		Low = Low + 1
	elif subject_data[subject][level] == "Medium":
		Medium = Medium + 1
	elif subject_data[subject][level] == "High":
		High = High + 1
#print result
print("Low level :",Low)
print("Medium level :",Medium)
print("High level :",High)
print('\n')
print('\n')


#barplot ( descriptive statistic )
print('barplot')
x=['Low','Medium','High']
y=[Low,Medium,High] 
plt.figure(figsize=(6,6))
plt.bar(x,y)
plt.show()
print('\n')
print('\n')

#---count cancer level by sex---#
#first we count the male-low | male-median | male-high
count_male_L = []
count_male_M = []
count_male_H = []
for subject in range(total):
	if subject_data[subject][level] == "Low" and subject_data[subject][gender] == male:
		count_male_L.append(subject_data[subject][level])
	elif subject_data[subject][level] == "Medium" and subject_data[subject][gender] == male:
		count_male_M.append(subject_data[subject][level])
	elif subject_data[subject][level] == "High" and subject_data[subject][gender] == male:
		count_male_H.append(subject_data[subject][level]) 
#print(len(count_male_L),len(count_male_M),len(count_male_H))

#collect the levels of male into a list
male_level_list =[len(count_male_L),len(count_male_M),len(count_male_H)]



##EXERCISE##
#then we count the female-low | female-median | female-high
# count_female_L = []
# count_female_M = []
# count_female_H = []
# for female_level in range(total):
# 	if subject_data[female_level][level] == "Low" and subject_data[female_level][2] == 2:
# 		count_female_L.append(subject_data[female_level][level])
# 	elif subject_data[female_level][level] == "Medium" and subject_data[female_level][2] == 2:
# 		count_female_M.append(subject_data[female_level][level])
# 	elif subject_data[female_level][level] == "High" and subject_data[female_level][2] == 2:
# 		count_female_H.append(subject_data[female_level][level]) 
# print(len(count_female_L),len(count_female_M),len(count_female_H))
####


count_female_L = 0
count_female_M = 0
count_female_H = 0
for female_level in range(total):
 	if subject_data[female_level][level] == "Low" and subject_data[female_level][gender] == female:
         count_female_L = count_female_L + 1 
 	elif subject_data[female_level][level] == "Medium" and subject_data[female_level][gender] == female:
		 count_female_M = count_female_M + 1
 	elif subject_data[female_level][level] == "High" and subject_data[female_level][gender] == female:
		 count_female_H = count_female_H + 1
#print(count_female_L,count_female_M,count_female_H)

#collect the levels of female into a list
female_level_list =[count_female_L,count_female_M,count_female_H]

#then draw a barplot of this result
labels = ['Low','Medium','High']
x = np.arange(len(labels))  # the label locations
width = 0.35  # the width of the bars
fig, ax = plt.subplots()
rects1 = ax.bar(x - width/2,male_level_list , width, label='Men')
rects2 = ax.bar(x + width/2,female_level_list, width, label='Women')
ax.set_ylabel('Amount')
ax.set_title('levels by gender')
ax.set_xticks(x)
ax.set_xticklabels(labels)
ax.legend()
plt.show()
print('\n')
#we can write down a chart of the levels comparing male and female.
#by the total above.


print('#----the correlation between age and level----#')
#first find out the IQR of age in Low levels#
print("#----for Low level----#")
age_low_list =[]
for subject in range(total):
	if subject_data[subject][level] == "Low":
		age_low_list.append(subject_data[subject][1])
#print(age_low_list)

#check whether Q2 == median
print("Q2 :",np.percentile(age_low_list,50))
print("Median :",stat.median(age_low_list))
# Q1 Q2 Q3#
#Q2 = stat.median(age_low_list)
Q2 = np.percentile(age_low_list,50)
Q1 = np.percentile(age_low_list,25)
Q3 = np.percentile(age_low_list,75)
print("Q1 (Low level) :",Q1)
print("Q2 = Median (Low level)  :",Q2)
print("Q3 (Low level) :",Q3)

#IQR == Q3 - Q1
print("IQR (Low level) :",Q3 - Q1)
print('\n')



##EXERCISE##
#then find out the IQR of age in medium level#
print("#----for Medium level----#")
age_Medium_list =[]
for subject in range(total):
	if subject_data[subject][level] == "Medium":
		age_Medium_list.append(subject_data[subject][1])
#print(age_Medium_list)

# Q1 Q2 Q3#
#Q2 = stat.median(age_Medium_list)
Q2 = np.percentile(age_Medium_list,50)
Q1 = np.percentile(age_Medium_list,25)
Q3 = np.percentile(age_Medium_list,75)
print("Q1 (Medium level) :",Q1)
print("Q2 = Median (Medium level)  :",Q2)
print("Q3 (Medium level) :",Q3)

#IQR == Q3 - Q1
print("IQR (Medium level) :",Q3 - Q1)
print('\n')
####


#then find out the IQR of age in High level#
print("#----for High level----#")
age_High_list =[]
for subject in range(total):
	if subject_data[subject][level] == "High":
		age_High_list.append(subject_data[subject][1])
#print(age_High_list)

# Q1 Q2 Q3#
#Q2 = stat.median(age_High_list)
Q2 = np.percentile(age_High_list,50)
Q1 = np.percentile(age_High_list,25)
Q3 = np.percentile(age_High_list,75)
print("Q1 (High level) :",Q1)
print("Q2 = Median (High level)  :",Q2)
print("Q3 (High level) :",Q3)

#IQR == Q3 - Q1
print("IQR (High level) :",Q3 - Q1)
print('\n')
print('\n')

#------scatter plot------#
Air_pollution_low = []
for s in range(total):
	if subject_data[s][level] == "Low":
		Air_pollution_low.append(subject_data[s][3])
#print(Air_pollution_low)

Air_pollution_medium = []
for s in range(total):
	if subject_data[s][level] == "Medium":
		Air_pollution_medium.append(subject_data[s][3])



Air_pollution_high= []
for s in range(total):
	if subject_data[s][level] == "High":
		Air_pollution_high.append(subject_data[s][3])



Dust_allergy_low = []
for s in range(total):
	if subject_data[s][level] == "Low":
		Dust_allergy_low.append(subject_data[s][5])


Dust_allergy_medium = []
for s in range(total):
	if subject_data[s][level] == "Medium":
		Dust_allergy_medium.append(subject_data[s][5])



Dust_allergy_high = []
for s in range(total):
	if subject_data[s][level] == "High":
		Dust_allergy_high.append(subject_data[s][5])




#print(zip(Air_pollution_low,Dust_allergy_low))
print('Plot')
fig = plt.figure()
#設定axes
ax = fig.add_subplot(1, 1, 1)

ax.scatter(Air_pollution_low,Dust_allergy_low, s=30, alpha=0.4,c="green")

ax.scatter(Air_pollution_medium,Dust_allergy_medium, s=30, alpha=0.4, c='blue')

ax.scatter(Air_pollution_high,Dust_allergy_high, s=30, alpha=0.4, c='red')

ax.grid(True)
ax.set_xlim(left=0, right=1.2)
ax.set_ylim(bottom=-0, top=1.2)
ax.set_xlabel('Air Pollution')
ax.set_ylabel('Dust allergy')
ax.set_title('Correlation of Air pollution & Dust allergy')
ax.legend(['Low', 'Medium', 'High'])
plt.xlim([0,9])
plt.ylim([0,9])
plt.show()
print('\n')

