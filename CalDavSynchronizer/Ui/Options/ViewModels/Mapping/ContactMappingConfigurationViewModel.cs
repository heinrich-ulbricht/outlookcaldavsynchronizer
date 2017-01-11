﻿// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
// Copyright (c) 2015 Gerhard Zehetbauer
// Copyright (c) 2015 Alexander Nimmervoll
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CalDavSynchronizer.Contracts;

namespace CalDavSynchronizer.Ui.Options.ViewModels.Mapping
{
  public class ContactMappingConfigurationViewModel : ViewModelBase, ISubOptionsViewModel
  {
    private bool _mapBirthday;
    private bool _mapContactPhoto;
    private bool _keepOutlookPhoto;
    private bool _keepOutlookFileAs;
    private bool _fixPhoneNumberFormat;
    private bool _mapDistributionLists;
    private bool _isSelected;
    private bool _isExpanded;
    private DistributionListType _distributionListType;

    public bool MapBirthday
    {
      get { return _mapBirthday; }
      set
      {
        CheckedPropertyChange (ref _mapBirthday, value);
      }
    }

    public bool MapContactPhoto
    {
      get { return _mapContactPhoto; }
      set
      {
        CheckedPropertyChange (ref _mapContactPhoto, value);
      }
    }

    public bool KeepOutlookPhoto
    {
      get { return _keepOutlookPhoto; }
      set
      {
        CheckedPropertyChange(ref _keepOutlookPhoto, value);
      }
    }

    public bool KeepOutlookFileAs
    {
      get { return _keepOutlookFileAs; }
      set
      {
        CheckedPropertyChange(ref _keepOutlookFileAs, value);
      }
    }

    public bool FixPhoneNumberFormat
    {
      get { return _fixPhoneNumberFormat; }
      set
      {
        CheckedPropertyChange (ref _fixPhoneNumberFormat, value);
      }
    }

    public bool MapDistributionLists
    {
      get { return _mapDistributionLists; }
      set
      {
        CheckedPropertyChange(ref _mapDistributionLists, value);
      }
    }

    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        CheckedPropertyChange (ref _isSelected, value);
      }
    }

    public bool IsExpanded
    {
      get { return _isExpanded; }
      set
      {
        CheckedPropertyChange (ref _isExpanded, value);
      }
    }

    public DistributionListType DistributionListType
    {
      get { return _distributionListType; }
      set { CheckedPropertyChange(ref _distributionListType, value); }
    }

    public IList<Item<DistributionListType>> AvailableDistributionListTypes { get; } = new List<Item<DistributionListType>>
                                                                                     {
                                                                                         new Item<DistributionListType> (DistributionListType.Sogo, "SOGo VLIST"),
                                                                                     };

    public static ContactMappingConfigurationViewModel DesignInstance => new ContactMappingConfigurationViewModel
                                                                         {
                                                                             MapBirthday = true,
                                                                             MapContactPhoto = true,
                                                                             KeepOutlookPhoto = false,
                                                                             KeepOutlookFileAs = true,
                                                                             FixPhoneNumberFormat = false,
                                                                             DistributionListType = DistributionListType.Sogo,
                                                                             MapDistributionLists = true
                                                                         };

    
    public void SetOptions (CalDavSynchronizer.Contracts.Options options)
    {
      SetOptions(options.MappingConfiguration as ContactMappingConfiguration ?? new ContactMappingConfiguration());
    }

    public void SetOptions (ContactMappingConfiguration mappingConfiguration)
    {
      MapBirthday = mappingConfiguration.MapBirthday;
      MapContactPhoto = mappingConfiguration.MapContactPhoto;
      KeepOutlookPhoto = mappingConfiguration.KeepOutlookPhoto;
      KeepOutlookFileAs = mappingConfiguration.KeepOutlookFileAs;
      FixPhoneNumberFormat = mappingConfiguration.FixPhoneNumberFormat;
      MapDistributionLists = mappingConfiguration.MapDistributionLists;
      DistributionListType = mappingConfiguration.DistributionListType;
    }

    public void FillOptions (CalDavSynchronizer.Contracts.Options options)
    {
      options.MappingConfiguration = new ContactMappingConfiguration
                                     {
                                         MapBirthday = _mapBirthday,
                                         MapContactPhoto = _mapContactPhoto,
                                         KeepOutlookPhoto = _keepOutlookPhoto,
                                         KeepOutlookFileAs = _keepOutlookFileAs,
                                         FixPhoneNumberFormat = _fixPhoneNumberFormat,
                                         MapDistributionLists = _mapDistributionLists,
                                         DistributionListType = _distributionListType
                                     };
    }

    public string Name => "Contact mapping configuration";
    public IEnumerable<ITreeNodeViewModel> Items { get; } = new ITreeNodeViewModel[0];

    public bool Validate (StringBuilder errorMessageBuilder)
    {
      return true;
    }

    public IEnumerable<ISubOptionsViewModel> SubOptions => new ISubOptionsViewModel[] { };
  }
}