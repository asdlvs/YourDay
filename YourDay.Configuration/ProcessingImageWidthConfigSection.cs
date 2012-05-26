using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YourDay.Configuration
{
    public class ProcessingImageSizeConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("sizes")]
        [ConfigurationCollection(typeof(Sizes), AddItemName = "size")]
        public Sizes Sizes
        {
            get { return (Sizes)this["sizes"]; }
            set { this["sizes"] = value; }
        }

        [ConfigurationProperty("avatarSizes")]
        [ConfigurationCollection(typeof(AvatarSizes), AddItemName = "add")]
        public AvatarSizes AvatarSizes
        {
            get { return (AvatarSizes)this["avatarSizes"]; }
            set { this["avatarSizes"] = value; }
        }
    }

    public class Sizes : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new Size();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Size)element).Width;
        }
    }

    public class AvatarSizes : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AvatarSize();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AvatarSize)element).Width;
        }
    }

    public class Size : ConfigurationElement
    {
        [ConfigurationProperty("width", IsKey=true, IsRequired=true)]
        public int Width
        {
            get { return (int)this["width"]; }
        }

        [ConfigurationProperty("height", IsKey = true, IsRequired = true)]
        public int Height
        {
            get { return (int)this["height"]; }
        }
    }

    public class AvatarSize : ConfigurationElement
    {
        [ConfigurationProperty("width", IsKey = true, IsRequired = true)]
        public int Width
        {
            get { return (int)this["width"]; }
        }
    }
}
