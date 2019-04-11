using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frågesport
{
    class QuestionHelper
    {

    }

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "test")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "test", IsNullable = false)]
    public partial class quiz
    {

        private quizCategory[] categoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("category")]
        public quizCategory[] category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "test")]
    public partial class quizCategory
    {

        private string nameField;

        private quizCategoryQuestion[] questionField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("question")]
        public quizCategoryQuestion[] question
        {
            get
            {
                return this.questionField;
            }
            set
            {
                this.questionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "test")]
    public partial class quizCategoryQuestion
    {

        private string textField;

        private string answerField;

        private string typeField;

        private string mediaFileField;

        private byte pointField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public string answer
        {
            get
            {
                return this.answerField;
            }
            set
            {
                this.answerField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string mediaFile
        {
            get
            {
                return this.mediaFileField;
            }
            set
            {
                this.mediaFileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte point
        {
            get
            {
                return this.pointField;
            }
            set
            {
                this.pointField = value;
            }
        }
    }


}
