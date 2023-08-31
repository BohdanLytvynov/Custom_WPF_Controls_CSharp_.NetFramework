using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomControlsLibrary.Utilities
{
    public class ResourceSwaper
    {
        #region Fields

        private readonly ResourceDictionary m_resourceDictionary;

        #endregion

        #region Ctor
        public ResourceSwaper(ResourceDictionary resources)
        {
            if (resources != null)
                m_resourceDictionary = resources;
            else
                throw new NullReferenceException("Resources dictionary wasn't set!!!");
        }
        #endregion

        public void Swap<TResource>(string resName, TResource resource)
        {
            if (resource == null || !m_resourceDictionary.Contains(resName))            
                return;
            
            m_resourceDictionary[resName] = resource;
        }
    }
}
