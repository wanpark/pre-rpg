using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{

    public enum Sex
    {
        Male,
        Female
    }

    abstract class Character
    {

        public Job Job
        {
            get { return job; }
            set
            {
                job = value;
                OnJobChanged();
            }
        }
        private Job job;

        public Sex Sex
        {
            get { return sex; }
        }
        private Sex sex;

        public abstract Party Party
        {
            get;
        }


        public bool Alive
        {
            get { return alive; }
        }
        private bool alive;


        public int Hp
        {
            get { return hp; }
        }
        private int hp;

        public int Mp
        {
            get { return mp; }
        }
        private int mp;

        public int MaxHp
        {
            get { return job.MaxHp; }
        }
        public int MaxMp
        {
            get { return job.MaxMp; }
        }


        public event EventHandler Died;
        public event EventHandler JobChanged;

        public Character(Sex sex, Job job)
        {
            this.job = job;
            this.sex = sex;
            ResetStatus();
        }

        protected void OnJobChanged()
        {
            if (JobChanged != null)
                JobChanged(this, EventArgs.Empty);
        }

        public void ResetStatus()
        {
            alive = true;
            hp = job.MaxHp;
            mp = job.MaxMp;
        }


        public void Die()
        {
            if (!alive)
                return;

            alive = false;
            if (Died != null)
                Died(this, EventArgs.Empty);
        }

        public void Damage(int ammount)
        {
            hp -= ammount;
            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
        }
    }
}
