using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject {
    public void suscribe(Observer o);
    public void deSuscribe(Observer o);
    public void notify();
}
