
// =================================	
// Preprocessors.
// =================================

// ...

// =================================	
// Namespaces.
// =================================

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// =================================	
// Define namespace.
// =================================

namespace MirzaBeig
{

    namespace Common
    {

        // =================================	
        // Classes.
        // =================================

        //[System.Serializable]

        public static class GenericCopier<T>
        {
            // =================================	
            // Nested classes and structures.
            // =================================

            // ...

            // =================================	
            // Variables.
            // =================================

            // ...

            // =================================	
            // Functions.
            // =================================

            // Source: http://stackoverflow.com/questions/4054075/how-to-make-a-deep-copy-of-an-array-in-c.
            // For copying arrays of arrays, this is slower than cloning and then using Array.Copy().

            public static T deepCopy(object obj)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    binaryFormatter.Serialize(memoryStream, obj);

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    return (T)binaryFormatter.Deserialize(memoryStream);
                }
            }

            // =================================	
            // End functions.
            // =================================

        }

        // =================================	
        // End namespace.
        // =================================

    }

}

// =================================	
// --END-- //
// =================================
