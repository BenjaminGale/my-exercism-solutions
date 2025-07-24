#include "leap.h"

namespace leap {

	int is_divisible_by(int num, int year)
	{
		return year % num == 0;
	}

	int is_leap_year(int year)
	{
		if (is_divisible_by(4, year))
		{
			if (is_divisible_by(100, year))
			{
				return !is_divisible_by(400, year);
			}

			return false;
		}

		return false;
	}	

}  // namespace leap
