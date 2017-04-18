using System;
using System.Collections.Generic;

namespace TestDemo
{
	public interface IDBManager
	{
		void createDataBase(string path);
		void createTables();

		void saveUserInfo(UserInfoModel userInfoModel);
		UserInfoModel getUserInfo();
		void deleteUserInfo();
		void saveRestaurantInfo(List<RestruantModel> restaurentModels);
		List<RestruantModel> getAllRestaurants();

		void saveSetting(SettingsModel settingModel);
		SettingsModel getCurrentSetting();
		void deleteCurrentSetting();
	}
}
