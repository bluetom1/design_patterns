namespace DesignPatterns.行为型;

/*
 * 备忘录模式（Memento Pattern）
 * 备忘录模式是一种行为型模式，又叫做快照模式（Snapshot Pattern）或Token模式，在不破坏封闭的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。
 * 这样以后就可将该对象恢复到原先保存的状态。
 * 它提供了一种状态恢复的实现机制，使得用户可以方便地回到一个特定的历史步骤，当新的状态无效或者存在问题时，可以使用暂时存储起来的备忘录将状态复原。
 * 备忘录实现了对信息的封装，一个备忘录对象是一种原发器对象状态的表示，不会被其他代码所改动。
 * 备忘录保存了原发器的状态，采用列表、堆栈等集合来存储备忘录对象可以实现多次撤销操作。
 */

/// <summary>
///     备忘录模式（Memento Pattern）
/// </summary>
internal class MementoPattern
{
    public static void Test()
    {
        var persons = new List<ContactPerson>
        {
            new() {Name = "C", MobileNum = "13756863001"},
            new() {Name = "C#", MobileNum = "13756863002"},
            new() {Name = "Java", MobileNum = "13756863003"}
        };

        var mobileOwner = new MobileOwner(persons);
        mobileOwner.Show();

        // 创建备忘录并保存备忘录对象
        var caretaker = new Caretaker {ContactM = mobileOwner.CreateMemento()};

        // 更改发起人联系人列表
        Console.WriteLine();
        Console.WriteLine("------删除一个联系人------");
        mobileOwner.ContactPersons.RemoveAt(2);
        mobileOwner.Show();

        // 恢复到原始状态
        Console.WriteLine();
        Console.WriteLine("-------恢复联系人列表------");
        mobileOwner.RestoreMemento(caretaker.ContactM);
        mobileOwner.Show();
    }

    public class ContactPerson
    {
        public string Name { get; set; }
        public string MobileNum { get; set; }
    }

    /// <summary>
    ///     发起人
    /// </summary>
    public class MobileOwner
    {
        // 发起人需要保存的内部状态
        public List<ContactPerson> ContactPersons { get; set; }

        public MobileOwner(List<ContactPerson> persons)
        {
            ContactPersons = persons;
        }

        // 创建备忘录，将当期要保存的联系人列表导入到备忘录中 
        public ContactMemento CreateMemento()
        {
            return new ContactMemento(Utils.ReflectionCloneList<ContactPerson, ContactPerson>(ContactPersons));
        }

        // 将备忘录中的数据备份导入到联系人列表中
        public void RestoreMemento(ContactMemento memento)
        {
            ContactPersons = Utils.ReflectionCloneList<ContactPerson, ContactPerson>(memento.ContactPersonBack);
        }

        public void Show()
        {
            Console.WriteLine("联系人列表中有{0}个人，具体是:", ContactPersons.Count);
            foreach (var p in ContactPersons)
            {
                Console.WriteLine("姓名: {0} 号码为: {1}", p.Name, p.MobileNum);
            }
        }
    }

    /// <summary>
    ///     备忘录
    /// </summary>
    public class ContactMemento
    {
        // 保存发起人的内部状态
        public List<ContactPerson> ContactPersonBack;

        public ContactMemento(List<ContactPerson> persons)
        {
            ContactPersonBack = persons;
        }
    }

    /// <summary>
    ///     管理角色
    /// </summary>
    public class Caretaker
    {
        public ContactMemento ContactM { get; set; }
    }
}