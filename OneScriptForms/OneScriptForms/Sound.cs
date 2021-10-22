using ScriptEngine.Machine.Contexts;
using System.Runtime.InteropServices;

namespace osf
{
    public class Sound
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern int PlaySound([MarshalAs(UnmanagedType.VBByRefStr)] ref string name, int hmod, int flags);
        public ClSound dll_obj;

        public void Play(string filename)
        {
            try
            {
                Sound.PlaySound(ref filename, 0, 131073);
            }
            catch
            {
            }
        }

        public void PlaySystem(string name)
        {
            Sound.PlaySound(ref name, 0, 65539);
        }
    }

    [ContextClass ("КлЗвук", "ClSound")]
    public class ClSound : AutoContext<ClSound>
    {
        public ClSound()
        {
            Sound Sound1 = new Sound();
            Sound1.dll_obj = this;
            Base_obj = Sound1;
        }
		
        public ClSound(Sound p1)
        {
            Sound Sound1 = p1;
            Sound1.dll_obj = this;
            Base_obj = Sound1;
        }
        
        public Sound Base_obj;
        
        [ContextMethod("Воспроизвести", "Play")]
        public void Play(string p1)
        {
            Base_obj.Play(p1);
        }

        [ContextMethod("ВоспроизвестиСистемныйЗвук", "PlaySystem")]
        public void PlaySystem(int p1)
        {
            if (p1 == 0)
            {
                System.Media.SystemSounds.Question.Play();
            }
            else if (p1 == 1)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            else if (p1 == 2)
            {
                System.Media.SystemSounds.Beep.Play();
             }
             else if (p1 == 3)
             {
                 System.Media.SystemSounds.Asterisk.Play();
             }
             else if (p1 == 4)
             {
                 System.Media.SystemSounds.Hand.Play();
             }
         }
    }
}
