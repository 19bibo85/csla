﻿using System;
using Csla;
using ProjectTracker.Dal;

namespace ProjectTracker.Library.Admin
{
  [Serializable]
  public class RoleEditManager : CommandBase<RoleEditManager>
  {
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    private int Id
    {
      get { return ReadProperty(IdProperty); }
      set { LoadProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<RoleEdit> RoleEditProperty = RegisterProperty<RoleEdit>(c => c.RoleEdit);
    private RoleEdit RoleEdit
    {
      get { return ReadProperty(RoleEditProperty); }
      set { LoadProperty(RoleEditProperty, value); }
    }

    [Create]
    [RunLocal]
    private void Create(int id)
    {
      Id = id;
    }

    [Create]
    [RunLocal]
    private void Create(RoleEdit role)
    {
      RoleEdit = role;
    }

    [Execute]
    private void Execute([Inject] IRoleDal dal)
    {
      if (Id > 0)
        GetRoleEdit(dal);
      else
        SaveRoleEdit();
    }

    private void GetRoleEdit([Inject] IRoleDal dal)
    {
      var portal = ApplicationContext.GetRequiredService<IChildDataPortal<RoleEdit>>();
      var item = dal.Fetch(Id);
      RoleEdit = portal.FetchChild(item);
    }

    private void SaveRoleEdit()
    {
      var portal = ApplicationContext.GetRequiredService<IDataPortal<RoleEditList>>();
      var list = portal.Fetch();
      var item = list.GetRoleById(RoleEdit.Id);
      if (item == null)
        list.Add(RoleEdit);
      else
        item.Name = RoleEdit.Name;
      list.Save();
    }
  }
}