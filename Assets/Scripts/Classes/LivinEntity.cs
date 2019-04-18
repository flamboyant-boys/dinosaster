using System.Text;
using System;

namespace PlayableCharacters
{
    public class LivinEntity
    {
        private string id;
        private string name;
        private float percentage;
        private float hitPercentage;

        /// <summary>
        /// Create a living entity with base stats.
        /// </summary>
        public LivinEntity()
        {
            this.id = generateID("TmpDino");
            this.name = id;
            this.percentage = 0.0f;
            this.hitPercentage = 10.0f;
        }

        /// <summary>
        /// Create a living entity with given stats
        /// </summary>
        /// <param name="name">Name of the entity</param>
        /// <param name="hitPercentage">How much damage the attacks deal</param>
        public LivinEntity(string name, float hitPercentage)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            else
            {
                name = name.Trim();
            }

            this.id = generateID(name);
            this.name = name;
            this.percentage = 0;
            this.hitPercentage = hitPercentage;
        }

        /// <summary>
        /// Summary of the Class
        /// </summary>
        /// <returns>Summary in string format</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine("ID: " + id);
            ret.AppendLine("Name: " + name);
            ret.AppendLine("Percentage: " + percentage.ToString());
            ret.AppendLine("Hit percentage: " + hitPercentage.ToString());

            return ret.ToString();
        }

        /// <summary>
        /// Generate unique ID 
        /// </summary>
        /// <param name="name">Source Word</param>
        /// <returns>New unique ID with name</returns>
        private string generateID(string name)
        {
            return string.Format("{0}_{1:N}", name, Guid.NewGuid());
        }

        #region Getter&Setter
        public string Name {
            get { return name; }
        }

        public string ID {
            get { return id; }
        }

        public float Percentage {
            get { return percentage; }
        }

        public float HitPercentage {
            get { return hitPercentage; }
        }
        #endregion
    }
}
