# Made by Lord-Giganticus

import os
import shutil

program_location = os.getcwd()

os.mkdir('nonmp4')

mp4_files = 0
mp4_files2 = 0


MP4_Location = input("Please input the folder where ONE mp4 video is:")
os.chdir(MP4_Location)
print(os.getcwd())
input("If this is not the correct folder I swear...")

def returnnonmp4():
    os.chdir('nonmp4')
    for file in os.listdir(os.getcwd()):
        if file.endswith('.mp4') == False:
            shutil.move(file, MP4_Location)
    os.chdir(MP4_Location)
    shutil.rmtree('nonmp4')
for name in os.listdir(os.getcwd()):
    if os.path.isfile(name) == True:
        if name.endswith('.mp4') == False:
            shutil.move(name, 'nonmp4')
        elif name.endswith('.mp4') == True:
            mp4_files += 1
if mp4_files > 1:
    input("There is more than one mp4 file in the folder! Please move it and then press enter.")
    for file in os.listdir(os.getcwd()):
        if os.path.isfile(file) == True:
            if file.endswith('mp4') == True:
                mp4_files2 += 1
    if mp4_files2 > 1:
        input("Well I gave you the chance to move it and ya didn't. Press enter to crash the program.")
        exit()

print("Not all THP videos have audio. Do you wish to have audio for yours? Then type the corresponding number to your choice.\n[1] Yes\n[2] No")
Audio = input("")

if Audio == "1":
    wav_conv = open('wavconv.bat','w')
    wav_conv.write('for %%a in ("*.mp4") do ffmpeg -i "%%a" "input.wav"')
    wav_conv.close()

    MP4_Conv = open('MP4toTHP.bat', 'w')
    MP4_Conv.write('for %%a in ("*.mp4") do ffmpeg -i "%%a" "input.mp4"')
    MP4_Conv.close()

    os.system('cmd /c wavconv.bat')
    os.system('cmd /c MP4toTHP.bat')
    os.system('cmd /c ffmpeg -i input.mp4 -r 30 frame%03d.jpg')
    os.system('cmd /c thpconv -j *.jpg -s input.wav -d output.thp')
    os.system('cmd /c del /f *.bat')
    os.system('cmd /c del /f *.wav')
    os.system('cmd /c del /f *.jpg')
    os.system('cmd /c del /f input.mp4')
    returnnonmp4()

    print("Do you wish to rerun the program? If so type the corresponding number to your choice.\n [1] Yes\n [2] No")
    rerun = input("")

    if rerun == "1":
        os.chdir(program_location)
        os.system('cmd /c py -3 MP4toTHP.py')
    elif rerun == "2":
        exit()
    else:
        input("Whoops! That wasn't supposed to happen! Press enter to exit.")
        exit()      
elif Audio == "2":
    MP4_Conv = open('MP4toTHP.bat', 'w')
    MP4_Conv.write('for %%a in ("*.mp4") do ffmpeg -i "%%a" "input.mp4"')
    MP4_Conv.close()

    os.system('cmd /c MP4toTHP.bat')
    os.system('cmd /c del /f *.bat')
    os.system('cmd /c ffmpeg -i input.mp4 -r 30 frame%03d.jpg')
    os.system('cmd /c thpconv -j *.jpg -d output.thp')
    os.system('cmd /c del /f *.jpg')
    os.system('cmd /c del /f input.mp4')
    returnnonmp4()

    print("Do you wish to rerun the program? If so type the corresponding number to your choice.\n [1] Yes\n [2] No")
    rerun = input("")

    if rerun == "1":
        os.chdir(program_location)
        os.system('cmd /c py -3 MP4toTHP.py')
    elif rerun == "2":
        exit()
    else:
        input("Whoops! That wasn't supposed to happen! Press enter to exit.")
        exit()    
else:
    input("Whoops! That wasn't supposed to happen Press enter to exit.")
    exit()