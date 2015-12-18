
// =================================	
// Preprocessors.
// =================================

// ...

// =================================	
// Namespaces.
// =================================

// ...

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

        public static class StringUtility
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

            // Gets the name of a file from a given path.

            public static string getFileNameFromPath(string path, bool removeExtension = false)
            {
                int lastSlash = path.LastIndexOf("/") + 1;

                return path.Substring(lastSlash, (path.Length - lastSlash) -
                    (removeExtension ? path.Length - path.LastIndexOf(".") : 0));
            }

            // Removes extension from file path.

            public static string getFileWithoutExtension(string file)
            {
                int lastDecimal = file.LastIndexOf(".");
                return file.Substring(0, lastDecimal);
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
