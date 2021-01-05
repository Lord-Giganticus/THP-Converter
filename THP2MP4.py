import os
import shutil

program_location = os.getcwd()

THP_Location = input("Please input the folder of thp vids you wish to convert:")
os.chdir(THP_Location)
print(os.getcwd())
input("If this is not the correct folder I swear...")
os.mkdir('nonthp')
os.mkdir('mp4output')

for name in os.listdir('.'):
    if os.path.isfile(name) == True:
        if name.endswith('.thp') == False:
            shutil.move(name, 'nonthp')

THP_Conv = open('THPconv.bat', 'w')
THP_Conv.write('for %%a in ("*.thp") do ffmpeg -i "%%a" "mp4output/%%~na.mp4"')
THP_Conv.close()

os.system('cmd /c THPconv.bat')
os.system('cmd /c del /f *bat')
os.chdir('nonthp')
for file in os.listdir(os.getcwd()):
    if os.path.isfile(file) == True:
        if file.endswith('.thp') == False:
            shutil.move(file, THP_Location)
os.chdir(THP_Location)
shutil.rmtree('nonthp')

print("Do you wish to rerun this in another folder? If so, type the corresponding number to your choice. \n [1] Yes \n [2] No.")
Rerun_Program = input()

if Rerun_Program == "1":
    os.chdir(program_location)
    os.system('cmd /c py -3 THP2MP4.py')
elif Rerun_Program == "2":
    exit()
else:
    input("Whoops! That wasn't supposed to happen! Press enter to exit.")
    exit()
