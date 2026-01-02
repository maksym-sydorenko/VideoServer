using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Interfaces;
using System.Windows.Forms;

namespace VideoServer.Tools
{
    internal class CameraCollection : CollectionBase
    {
        Hashtable tableIAdaptee = null;

        // Add new _camera to the collection
        public void Add(Camera camera)
        {
            InnerList.Add(camera);
        }

        // Remove _camera from the collection
        public void Remove(Camera camera)
        {
            InnerList.Remove(camera);
        }

        // Get _camera with specified name
        public Camera GetCamera(string name)
        {
            // find the _camera
            foreach (Camera camera in InnerList)
            {
                //if (_camera.Name == name) 
                //    return _camera;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Camera this[int index]
        {
            get
            {
                return ((Camera)InnerList[index]);
            }
        }
        // Load all video providers
        public void Load(string path, ref Hashtable tableIAdaptee)
        {
            try
            {
                // create directory info
                DirectoryInfo dir = new DirectoryInfo(path);
                this.tableIAdaptee = tableIAdaptee;
                // get all dll files from the directory
                FileInfo[] files = dir.GetFiles("*.dll");

                // walk through all files
                foreach (FileInfo f in files)
                {
                    LoadAssembly(Path.Combine(path, f.Name));
                }

                // sort providers list
                //InnerList.Sort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        /// <summary>
        /// Load assembly and find video provider descriptors there
        /// </summary>
        /// <param name="fname"></param>
        private void LoadAssembly(string fname)
        {
            Type typeCameraAdaptee = typeof(ISourceAdaptee);

            Assembly asm = null;

            try
            {
                // try to load assembly
                asm = Assembly.LoadFrom(fname);

                // get types of the assembly
                Type[] types = asm.GetTypes();

                // check all types
                foreach (Type type in types)
                {
                    // get interfaces ot the type
                    Type[] interfaces = type.GetInterfaces();

                    // check, if the type is inherited from ICameraDescription
                    if (Array.IndexOf(interfaces, typeCameraAdaptee) != -1)
                    {
                        ISourceAdaptee desc = null;
                        Camera camera = null;
                        try
                        {
                            // create an instance of the type
                            desc = (ISourceAdaptee)Activator.CreateInstance(type);
                            camera = new Camera();
                            tableIAdaptee.Add(desc.CameraType, desc);
                            camera.ISourceAdaptee = desc;
                            // create provider object
                            InnerList.Add(camera);
                        }
                        catch (Exception)
                        {
                            // something failed during instance creatinion
                        }
                    }

                }
            }
            catch (Exception)
            {
            }
        }
    }
}
