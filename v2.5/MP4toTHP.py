import sys, os

wav_file = bool(False)


if len(sys.argv) < 1:
    print("There MUST be at least one argument!")
    exit()

file = sys.argv[1]
folder = os.path.dirname(file)
name = os.path.splitext(file)
name = name[0]
if os.path.isfile(file) == False:
    print("Argument is not a valid file.")
    exit()
else:
    if file.endswith('.mp4') == False:
        print("File is not a mp4 file.")
        exit()
os.chdir(folder)

try:
    os.system('THPConv')
except:
    if os.path.isfile('THPConv.exe') == False and os.path.isfile('dsptool.dll') == False:
        os.system('cmd /c curl https://chaos-crew.000webhostapp.com/FastDL/THP.zip -o THP.zip')
        os.system('cmd /c 7z x "THP.zip" -o"'+folder+'" -r')
        os.remove('THP.zip')

try:
    sys.argv[2]
    if sys.argv[2].endswith('-a') == True:
        wav_file = bool(True)
except:
    pass

if wav_file == True:
    os.system('cmd /c ffmpeg -i "'+file+'" "input.wav"')

os.system('cmd /c ffmpeg -i "'+file+'" -r 30 frame%03d.jpg')

if os.path.isfile('input.wav') == False:
    os.system('cmd /c thpconv -j *.jpg -d "'+name+'.thp"')
else:
    os.system('cmd /c thpconv -j *.jpg -s input.wav -d "'+name+'.thp"')
    os.remove('input.wav')
os.system('cmd /c del /f *.jpg')

print("Complete.")
exit()