﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interaction {
    void DoActionNow(GameObject caller);
    void SetHighlighted(bool highlighted);
}
