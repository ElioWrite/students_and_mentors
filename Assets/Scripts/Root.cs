﻿using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    #region SINGLETONE

    private static Root _instance;
    public static Root Instance => _instance ?? (_instance = FindObjectOfType<Root>());

    #endregion

    [SerializeField]
    private ScenesModel _scenesModel;
    public ScenesModel Scenes => _scenesModel;

    [SerializeField]
    private NetworkModel _networkModel;
    public NetworkModel Network => _networkModel;

    [SerializeField]
    private InputModel _inputModel;
    public InputModel Input => _inputModel;

    [SerializeField]
    private DataModel _dataModel;
    public DataModel Data => _dataModel;

    [SerializeField]
    private StatesModel _statesModel;
    public StatesModel States => _statesModel;

    [SerializeField]
    private StudentsModel _studentsModel;
    public StudentsModel Students => _studentsModel;

    [SerializeField]
    private MentorsModel _mentorsModel;
    public MentorsModel Mentors => _mentorsModel;

    [SerializeField]
    private ShufflesModel _shuffleModel;
    public ShufflesModel Shuffle => _shuffleModel;
}
